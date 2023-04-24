using BookingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users2Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult GetUser([FromQuery] int count)
        {
            User[] User = {
                new() { Name= "Alex" },
                new() { Name= "Octavian" },
                new() { Name= "Ionel" },
            };
            if (!User.Any())
                return NotFound();
            return Ok(User.Take(count));
        }

        [HttpPost]
        public ActionResult CreateNewUser([FromBody] User newUser)
        {
            bool isCreated = false;
            if (isCreated)
            {
                return BadRequest();
            }


            return Created("", newUser);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            bool badThingsHappened = false;

            if (badThingsHappened)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id)
        {
            bool updateNotSucceded = false;

            if (updateNotSucceded)
                return BadRequest();
            return NoContent();
        }
    }
}
