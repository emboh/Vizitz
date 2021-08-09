using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vizitz.Entities;
using Vizitz.IRepository;
using Vizitz.Models;
using Vizitz.Models.Paginate;
using Vizitz.Services;
using X.PagedList;

namespace Vizitz.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietorController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly ILogger<ProprietorController> _logger;

        private readonly IMapper _mapper;

        private readonly IAuthManager _authManager;

        private readonly IUnitOfWork _unitOfWork;

        public ProprietorController(
            UserManager<User> userManager,
            ILogger<ProprietorController> logger,
            IMapper mapper,
            IAuthManager authManager,
            IUnitOfWork unitOfWork
            )
        {
            _userManager = userManager;

            _logger = logger;

            _mapper = mapper;

            _authManager = authManager;

            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProprietorDTO>>> GetProprietor([FromQuery] RequestParams requestParams)
        {
            var proprietors = await _unitOfWork.Proprietors.GetPagedList(requestParams);

            var metadata = new
            {
                proprietors.Count,
                proprietors.PageSize,
                proprietors.PageCount,
                proprietors.PageNumber,
                proprietors.HasNextPage,
                proprietors.HasPreviousPage,
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

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
            User proprietor = await _unitOfWork.Proprietors.Get(u => u.Id == id);

            if (proprietor == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProprietorDTO>(proprietor);
        }

        [Authorize(Roles = $"{Role.Administrator}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        [Authorize(Roles = $"{Role.Administrator},{Role.Proprietor}")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutProprietor(Guid id, [FromBody] UpdateProprietorDTO proprietorDTO)
        {
            User proprietor = await _unitOfWork.Proprietors.Get(u => u.Id == id);

            if (proprietor == null)
            {
                _logger.LogError($"Invalid attempt in {nameof(PutProprietor)}");

                return NotFound();
            }

            _mapper.Map(proprietorDTO, proprietor);

            _unitOfWork.Proprietors.Update(proprietor);

            await _unitOfWork.Save();

            //await _userManager.UpdateAsync(proprietor);

            return NoContent();
        }

        [Authorize(Roles = $"{Role.Administrator}")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProprietor(Guid id)
        {
            User proprietor = await _unitOfWork.Proprietors.Get(u => u.Id == id);

            if (proprietor == null)
            {
                _logger.LogError($"Invalid attempt in {nameof(DeleteProprietor)}");

                return NotFound();
            }

            await _unitOfWork.Proprietors.Delete(id);

            await _unitOfWork.Save();

            //await _userManager.DeleteAsync(proprietor);

            return NoContent();
        }
    }
}
