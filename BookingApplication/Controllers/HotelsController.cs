﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;
using BookingApplication.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly DataContext _context;

        public HotelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels([FromQuery] PaginationFilter filter)
        {
            var validPageFilter = new PaginationFilter(filter.per_page, filter.current_page);
            var hotelData = await _context.Hotels.Include(x => x.Reviews).ThenInclude(x => x.User)
                .Skip((validPageFilter.current_page - 1) * validPageFilter.per_page)
                .Take(validPageFilter.per_page)
                .ToListAsync();

            var countTotal = await _context.Hotels.CountAsync();

            return Ok(new PaginatedResponse<List<Hotel>>(countTotal, validPageFilter.per_page, validPageFilter.current_page, hotelData));
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel([FromRoute]int id)
        {
          if (_context.Hotels == null)
          {
              return NotFound();
          }
          var hotel = await _context.Hotels.Include(x => x.Reviews).ThenInclude(x => x.User).FirstOrDefaultAsync(i => i.Id == id);

          if (hotel == null)
          {
              return NotFound();
          }

          return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
          if (_context.Hotels == null)
          {
              return Problem("Entity set 'DataContext.Hotels'  is null.");
          }
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return (_context.Hotels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
