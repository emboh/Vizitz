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

namespace Vizitz.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly ILogger<ProprietorsController> _logger;

        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<ProprietorsController> logger, 
            IMapper mapper)
        {
            _userManager = userManager;

            _signInManager = signInManager;

            _logger = logger;

            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] VisitorDTO visitorDTO)
        {
            _logger.LogInformation($"Registration for {visitorDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                User user = _mapper.Map<User>(visitorDTO);

                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest($"User registration attempt failed");
                }

                return Accepted();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Problem in the {nameof(Register)}");

                return Problem($"Problem in the {nameof(Register)}", statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
