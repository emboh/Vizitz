using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            _logger.LogInformation($"Registration for {registerDTO.Email}");

            // TODO : move role validation to RegisterDTO
            foreach (var role in registerDTO.Roles)
            {
                if (!Role.AllowedRoles.Contains(role, StringComparer.OrdinalIgnoreCase))
                {
                    return Problem($"Role {role} doesn't exist.", statusCode: StatusCodes.Status400BadRequest);
                }
            }

            try
            {
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
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Problem in the {nameof(Register)}");

                return Problem($"Problem in the {nameof(Register)}", statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            _logger.LogInformation($"Login attempt for {loginDTO.Email}");

            try
            {
                if (!await _authManager.ValidateUser(loginDTO))
                {
                    return Unauthorized();
                }

                return Ok(new { Token = await _authManager.CreateToken() });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Problem in the {nameof(Login)}");

                return Problem($"Problem in the {nameof(Login)}", statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
