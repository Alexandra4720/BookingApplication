using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Models
{
    [Table("Users")]
    public record User
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //rol
        public string Role { get; set; }
    }
}
