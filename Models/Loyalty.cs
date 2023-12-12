using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TermProject.Models
{
    public class Loyalty
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "Please enter your first name (2 characters or more).")]
        [StringLength(30, ErrorMessage = "Please enter your first name (max 30 characters).")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Please enter your last name (max 30 characters).")]
        public string? LastName { get; set; }

        [Display(Name = "City")]
        [StringLength(30, ErrorMessage = "Please enter your city (max 30 characters).")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string? City {  get; set; }

        [Display(Name = "State")]
        [StringLength(30, ErrorMessage = "Please enter your state (max 30 characters).")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string? State { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Phone #")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Tier Reward")]
        public int MenuId { get; set; }
        public Menu? Menu { get; set; }
    }
}
