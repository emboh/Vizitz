using AutoMapper;
using Bogus.DataSets;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Vizitz.Entities;
using Vizitz.Models;
using Vizitz.Models.Account;
using Vizitz.Services;

namespace Vizitz.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly RoleManager<Role> _roleManager;

        private readonly ILogger<AccountController> _logger;

        private readonly IMapper _mapper;

        private readonly IAuthManager _authManager;

        public AccountController(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager
            )
        {
            _userManager = userManager;

            _roleManager = roleManager;

            _logger = logger;

            _mapper = mapper;

            _authManager = authManager;
        }

        [ApiVersion("1.0")]
        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(Register))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            _logger.LogInformation($"Registration for {registerDTO.Email}");

            // TODO : move role validation to RegisterDTO
            string[] allowedRoles = { Role.Proprietor, Role.Visitor };

            foreach (var role in registerDTO.Roles)
            {
                if (!allowedRoles.Contains(role, StringComparer.OrdinalIgnoreCase))
                {
                    return Problem($"Role {role} doesn't exist.", statusCode: StatusCodes.Status400BadRequest);
                }
            }

            var user = _mapper.Map<User>(registerDTO);

            user.UserName = registerDTO.Email;

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            // TODO : use transaction to handle 2 operation
            await _userManager.AddToRolesAsync(user, registerDTO.Roles);

            return Ok(_mapper.Map<UserDTO>(user));
        }

        [ApiVersion("1.0")]
        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(Login))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(
            [FromServices] IAuthManager authManager, 
            [FromBody] LoginDTO loginDTO)
        {
            _logger.LogInformation($"Login attempt for {loginDTO.Email}");

            if (!await authManager.ValidateUser(loginDTO))
            {
                return Unauthorized();
            }

            return Ok(new { Token = await authManager.CreateToken() });
        }

        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 30)]
        [HttpCacheValidation(MustRevalidate = false)]
        [Route(nameof(Profile))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> Profile([FromServices] IAuthManager authManager)
        {
            string name = User.Identity?.Name;

            string userName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _logger.LogInformation($"Show profile for {name}");

            User user = await authManager.GetUserDetail(userName);

            return Ok(_mapper.Map<UserDTO>(user));
        }
    }
}
