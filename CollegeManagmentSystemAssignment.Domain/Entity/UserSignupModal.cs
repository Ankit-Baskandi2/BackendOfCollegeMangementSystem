using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeManagmentSystemAssignment.Domain.Entity
{
    [Table("tblUserDetails_Ankit")]
    public class UserSignupModal
    {
        [Key]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Only 10 digits are allowed for phone numbers.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Emai is required")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*()-_+=]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters and include a lowercase letter," +
            " an uppercase letter, a number, and a special character.")]
        public string? Password { get; set; }
    }
}
