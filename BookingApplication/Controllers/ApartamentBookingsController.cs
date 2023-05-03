using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Entities.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentBookingsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApartamentBookingsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ApartamentBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApartamentBooking>>> GetApartamentBookings()
        {
          if (_context.ApartamentBookings == null)
            {
              return NotFound();
          }
            return await _context.ApartamentBookings.Include(x => x.User).Include(x => x.Apartament).ToListAsync();

        }

        // GET: api/ApartamentBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApartamentBooking>> GetApartamentBooking(int id)
        {
          if (_context.ApartamentBookings == null)
          {
              return NotFound();
          }
            var apartamentBooking = await _context.ApartamentBookings.Include(x => x.User).Include(x => x.Apartament).FirstOrDefaultAsync(i => i.Id == id);

            if (apartamentBooking == null)
            {
                return NotFound();
            }

            return apartamentBooking;
        }

        // PUT: api/ApartamentBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartamentBooking(int id, ApartamentBooking apartamentBooking)
        {
            if (id != apartamentBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(apartamentBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentBookingExists(id))
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

        // POST: api/ApartamentBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApartamentBooking>> PostApartamentBooking(ApartamentBooking apartamentBooking)
        {
          if (_context.ApartamentBookings == null)
          {
              return Problem("Entity set 'DataContext.ApartamentBookings'  is null.");
          }
            _context.ApartamentBookings.Add(apartamentBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartamentBooking", new { id = apartamentBooking.Id }, apartamentBooking);
        }

        // DELETE: api/ApartamentBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartamentBooking(int id)
        {
            if (_context.ApartamentBookings == null)
            {
                return NotFound();
            }
            var apartamentBooking = await _context.ApartamentBookings.FindAsync(id);
            if (apartamentBooking == null)
            {
                return NotFound();
            }

            _context.ApartamentBookings.Remove(apartamentBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartamentBookingExists(int id)
        {
            return (_context.ApartamentBookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
