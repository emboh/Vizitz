using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vizitz.Data;
using Vizitz.Entities;
using Vizitz.IRepository;
using Vizitz.Models;

namespace Vizitz.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<ProprietorsController> _logger;

        private readonly IMapper _mapper;

        public ProprietorsController(IUnitOfWork unitOfWork, ILogger<ProprietorsController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/Proprietors
        [HttpGet]
        //public async Task<IActionResult> GetUser()
        public async Task<ActionResult<IEnumerable<ProprietorDTO>>> GetUser()
        {
            var proprietors = await _unitOfWork.Users.GetAll();

            return Ok(_mapper.Map<IList<ProprietorDTO>>(proprietors));
        }

        // GET: api/Proprietors/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProprietorDTO>> GetUser(Guid id)
        {
            User proprietor = await _unitOfWork.Users.Get(q => q.Id == id, new List<string> { "Venues" });

            if (proprietor == null)
            {
                return BadRequest();
            }

            return _mapper.Map<ProprietorDTO>(proprietor);
        }

        // PUT: api/Proprietors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Proprietors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.User.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}

        // DELETE: api/Proprietors/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var user = await _context.User.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.User.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UserExists(int id)
        //{
        //    return _context.User.Any(e => e.Id == id);
        //}
    }
}
