using BookingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetBooking([FromQuery]int count)
        {
            Apartament[] Booking = {
                new() { City= "Iasi" },
                new() { City= "Bucuresti" },
                new() { City= "Brasov" },
            };
            if (!Booking.Any())
                return NotFound();
            return Ok(Booking.Take(count));
        }

        [HttpPost]
        public ActionResult CreateNewBooking([FromBody] RoomBooking newBooking)
        {
            bool isCreated=false;
            if (isCreated)
            {
                return BadRequest();
            }
                

            return Created("", newBooking);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            bool badThingsHappened = false;

            if (badThingsHappened)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBooking(int id)
        {
            bool updateNotSucceded = false;

            if(updateNotSucceded) 
                return BadRequest();
            return NoContent();
        }
    }*/
}
