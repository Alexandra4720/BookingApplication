using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Models
{
    [Table("ApartamentBookings")]
    public class ApartamentBooking
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int User_Id { get; set; }
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }
        public int NumberOfPeople { get; set; }

        [ForeignKey("User_Id")]
        public User User { get; set; }
    }
}
