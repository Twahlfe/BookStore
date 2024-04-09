using System.ComponentModel.DataAnnotations;

namespace a1_bookstore_ict715.Models
{
    public class ContactUsModel
    {
        [Key]
        public int ContactUsId { get; set; } // Primary key
        [Required(ErrorMessage = "Please enter a user name")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone number")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please let us know what you're curious about!")]
        public string? Message { get; set; }
    }
}
