using System.ComponentModel.DataAnnotations;

namespace CollegeManagmentSystemAssignment.Domain.Entity
{
    public class EmailAndPasswordModal
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
