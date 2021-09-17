using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Vizitz.Entities;
using Vizitz.IRepository;
using Vizitz.Models;
using Vizitz.Models.Paginate;
using Vizitz.Services;

namespace Vizitz.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly ILogger<VenueController> _logger;

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public VenueController(
            ILogger<VenueController> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;

            _mapper = mapper;

            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VenueDTO>>> GetVenue([FromQuery] RequestParams requestParams)
        {
            var venues = await _unitOfWork.Venues.GetPagedList(requestParams);

            var metadata = new
            {
                venues.Count,
                venues.PageSize,
                venues.PageCount,
                venues.PageNumber,
                venues.HasNextPage,
                venues.HasPreviousPage,
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(_mapper.Map<IList<VenueDTO>>(venues));
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = nameof(GetVenue))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VenueDTO>> GetVenue(Guid id)
        {
            Venue venue = await _unitOfWork.Venues.Get(q => q.Id == id);

            if (venue == null)
            {
                _logger.LogError($"Invalid attempt in {nameof(GetVenue)}");

                return NotFound();
            }

            return Ok(_mapper.Map<VenueDTO>(venue));
        }

        [Authorize(Roles = $"{Role.Administrator},{Role.Proprietor}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProprietorDTO>> PostVenue([FromBody] CreateVenueDTO venueDTO)
        {
            string proprietorId = User.FindFirstValue(ClaimTypes.Sid);

            venueDTO.ProprietorId = proprietorId;

            Venue venue = _mapper.Map<Venue>(venueDTO);

            await _unitOfWork.Venues.Insert(venue);

            await _unitOfWork.Save();

            return CreatedAtRoute(nameof(GetVenue), new { id = venue.Id }, _mapper.Map<VenueDTO>(venue));
        }

        [Authorize(Roles = $"{Role.Administrator},{Role.Proprietor}")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutVenue(Guid id, [FromBody] UpdateVenueDTO venueDTO)
        {
            Venue venue = await _unitOfWork.Venues.Get(q => 
                q.Id == id 
                && (
                    q.ProprietorId == new Guid(User.FindFirstValue(ClaimTypes.Sid)) 
                    || 
                    User.IsInRole(Role.Administrator)
                )
            );

            if (venue == null)
            {
                _logger.LogError($"Invalid attempt in {nameof(PutVenue)}");

                return NotFound();
            }

            _mapper.Map(venueDTO, venue);

            _unitOfWork.Venues.Update(venue);

            await _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = $"{Role.Administrator},{Role.Proprietor}")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteVenue(Guid id)
        {
            Venue venue = await _unitOfWork.Venues.Get(q =>
                q.Id == id
                && (
                    q.ProprietorId == new Guid(User.FindFirstValue(ClaimTypes.Sid))
                    || 
                    User.IsInRole(Role.Administrator)
                )
            );

            if (venue == null)
            {
                _logger.LogError($"Invalid attempt in {nameof(DeleteVenue)}");

                return NotFound();
            }

            await _unitOfWork.Venues.Delete(id);

            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
