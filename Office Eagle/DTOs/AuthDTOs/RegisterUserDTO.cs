using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Office_Eagle.Models;

namespace Office_Eagle.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        [StringLength(32, MinimumLength = 4)]
        [RegularExpression(
            @"^[a-zA-Z0-9]+$",
            ErrorMessage = "Username can only contain letters and numbers"
        )]
        public string Username { get; set; } = "";

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = "";

        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string FirstName { get; set; } = "";

        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string LastName { get; set; } = "";

        [EmailAddress]
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Email { get; set; } = "";

        [Phone]
        [Required]
        [StringLength(13, MinimumLength = 7)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Contact number can only contain numbers")]
        public string ContactNumber { get; set; } = "";

        [Required]
        [RegularExpression(
            @"^[A-Z0-9]+$",
            ErrorMessage = "Employee ID can only contain uppercase letters and numbers"
        )]
        [StringLength(10, MinimumLength = 5)]
        public string EmployeeID { get; set; } = "";

        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string Designation { get; set; } = "";

        [Required]
        [StringLength(32, MinimumLength = 2)]
        public string Department { get; set; } = "";

        [Required]
        [ForeignKey("Id")]
        public Guid ManagerId { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal LeaveBalance { get; set; } = 0;

        [Required]
        public Gender Gender { get; set; }
    }
}
