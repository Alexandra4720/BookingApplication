using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Models
{
    [Table("Hotels")]
    public class Hotel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }

        public List<HotelReview>? Reviews { get; set; }

    }
}
