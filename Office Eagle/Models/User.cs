using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Office_Eagle.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum Role
    {
        Employee,
        Manager,
        Admin
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
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
        public string ContactNumber { get; set; } = "";

        [Required]
        [RegularExpression(@"^[A-Z0-9]+$")]
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
        [Column(TypeName = "decimal(18,2)")]
        public decimal LeaveBalance { get; set; } = 0;

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Role Role { get; set; }

        public bool GotUpdate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            GotUpdate = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
