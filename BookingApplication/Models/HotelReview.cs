using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Models
{
    [Table("HotelReviews")]
    public record HotelReview
    {
        [Key]
        [Required]
        public int Id { get; set; }

        //public int User_Id { get; set; }
        public int User_Id {get; set;}
        public int Hotel_Id { get; set; }
        public string Body { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        
        [ForeignKey("User_Id")]
        public User User { get; set; }
        public Hotel Hotel { get; set; }
    }
}
