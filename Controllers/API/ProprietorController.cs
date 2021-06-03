using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vizitz.Entities;
using Vizitz.IRepository;
using Vizitz.Models;
using Vizitz.Services;

namespace Vizitz.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietorController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly RoleManager<Role> _roleManager;

        private readonly ILogger<ProprietorController> _logger;

        private readonly IMapper _mapper;

        private readonly IAuthManager _authManager;

        private readonly IUnitOfWork _unitOfWork;

        public ProprietorController(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ILogger<ProprietorController> logger,
            IMapper mapper,
            IAuthManager authManager,
            IUnitOfWork unitOfWork
            )
        {
            _userManager = userManager;

            _roleManager = roleManager;

            _logger = logger;

            _mapper = mapper;

            _authManager = authManager;

            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProprietorDTO>>> GetProprietor()
        {
            var role = await _roleManager.FindByNameAsync(Role.Proprietor);

            var proprietors = await _userManager.Users
                .Include(u => u.UserRoles.Where(r => r.RoleId == role.Id))
                .ThenInclude(ur => ur.Role)
                .AsNoTracking().ToListAsync();

            return Ok(_mapper.Map<IList<ProprietorDTO>>(proprietors));
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = nameof(GetProprietor))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProprietorDTO>> GetProprietor(Guid id)
        {
            User proprietor = await _userManager.Users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefaultAsync(u => u.Id == id);

            if (proprietor == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(proprietor);

            // TODO : check roles inside include operation
            if (!roles.Contains(Role.Proprietor))
            {
                return Problem($"User Role is not {Role.Proprietor}.", statusCode: StatusCodes.Status400BadRequest);
            }

            return _mapper.Map<ProprietorDTO>(proprietor);
        }

        [Authorize(Roles = Role.Administrator)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProprietorDTO>> PostProprietor([FromBody] CreateProprietorDTO proprietorDTO)
        {
            User proprietor = _mapper.Map<User>(proprietorDTO);

            proprietor.UserName = proprietorDTO.Email;

            var result = await _userManager.CreateAsync(proprietor, proprietorDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRoleAsync(proprietor, Role.Proprietor);

            return CreatedAtRoute(nameof(GetProprietor), new { id = proprietor.Id }, _mapper.Map<ProprietorDTO>(proprietor));
        }

        // TODO : Use constant from Role instead of hardcode
        [Authorize(Roles = "Administrator,Proprietor")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutProprietor(Guid id, [FromBody] UpdateProprietorDTO proprietorDTO)
        {
            User proprietor = await _userManager.FindByIdAsync(id.ToString());

            Venue venue = await _unitOfWork.Venues.Get(q => q.Id == id);

            if (proprietor == null)
            {
                _logger.LogError($"Invalid attempt in {nameof(PutProprietor)}");

                return NotFound();
            }

            _mapper.Map(proprietorDTO, proprietor);

            await _userManager.UpdateAsync(proprietor);

            return NoContent();
        }

        [Authorize(Roles = Role.Administrator)]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProprietor(Guid id)
        {
            User proprietor = await _userManager.Users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefaultAsync(u => u.Id == id);

            if (proprietor == null)
            {
                _logger.LogError($"Invalid attempt in {nameof(DeleteProprietor)}");

                return NotFound();
            }

            await _userManager.DeleteAsync(proprietor);

            return NoContent();
        }
    }
}
