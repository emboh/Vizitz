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

namespace Vizitz.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        private readonly ILogger<ProprietorsController> _logger;

        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            ILogger<ProprietorsController> logger, 
            IMapper mapper)
        {
            _userManager = userManager;

            _roleManager = roleManager;

            _logger = logger;

            _mapper = mapper;
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
                if (!Vizitz.Entities.User.Roles.Contains(role, StringComparer.OrdinalIgnoreCase))
                {
                    return Problem($"Role {role} doesn't exist", statusCode: StatusCodes.Status400BadRequest);
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

                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Problem in the {nameof(Register)}");

                return Problem($"Problem in the {nameof(Register)}", statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
