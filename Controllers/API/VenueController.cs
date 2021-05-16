﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vizitz.Entities;
using Vizitz.IRepository;
using Vizitz.Models;
using Vizitz.Models.Paginate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VenueDTO>>> GetVenue([FromQuery] RequestParams requestParams)
        {
            var venues = await _unitOfWork.Venues.GetPagedList(requestParams);

            return Ok(_mapper.Map<IList<VenueDTO>>(venues));
        }

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

            return _mapper.Map<VenueDTO>(venue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProprietorDTO>> PostVenue([FromBody] CreateVenueDTO venueDTO)
        {
            Venue venue = _mapper.Map<Venue>(venueDTO);

            await _unitOfWork.Venues.Insert(venue);

            await _unitOfWork.Save();

            return CreatedAtRoute(nameof(GetVenue), new { id = venue.Id }, _mapper.Map<VenueDTO>(venue));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutVenue(Guid id, [FromBody] UpdateVenueDTO venueDTO)
        {
            Venue venue = await _unitOfWork.Venues.Get(q => q.Id == id);

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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteVenue(Guid id)
        {
            Venue venue = await _unitOfWork.Venues.Get(q => q.Id == id);

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