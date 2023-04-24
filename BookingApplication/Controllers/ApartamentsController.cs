using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApplication.DAL;
using BookingApplication.Models;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApartamentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Apartaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apartament>>> GetApartaments()
        {
          if (_context.Apartaments == null)
          {
              return NotFound();
          }
            return await _context.Apartaments.ToListAsync();
        }

        // GET: api/Apartaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartament>> GetApartament(int id)
        {
          if (_context.Apartaments == null)
          {
              return NotFound();
          }
            var apartament = await _context.Apartaments.FindAsync(id);

            if (apartament == null)
            {
                return NotFound();
            }

            return apartament;
        }

        // PUT: api/Apartaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApartament(int id, Apartament apartament)
        {
            if (id != apartament.Id)
            {
                return BadRequest();
            }

            _context.Entry(apartament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentExists(id))
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

        // POST: api/Apartaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Apartament>> PostApartament(Apartament apartament)
        {
          if (_context.Apartaments == null)
          {
              return Problem("Entity set 'DataContext.Apartaments'  is null.");
          }
            _context.Apartaments.Add(apartament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApartament", new { id = apartament.Id }, apartament);
        }

        // DELETE: api/Apartaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApartament(int id)
        {
            if (_context.Apartaments == null)
            {
                return NotFound();
            }
            var apartament = await _context.Apartaments.FindAsync(id);
            if (apartament == null)
            {
                return NotFound();
            }

            _context.Apartaments.Remove(apartament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApartamentExists(int id)
        {
            return (_context.Apartaments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
