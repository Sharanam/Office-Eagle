using Office_Eagle.Models;

namespace Office_Eagle.DTOs
{
    public class ReadEmployeeDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = "";

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Email { get; set; } = "";

        public string ContactNumber { get; set; } = "";

        public string EmployeeID { get; set; } = "";

        public string Designation { get; set; } = "";
        public string Department { get; set; } = "";
        public Guid ManagerId { get; set; }
        public decimal LeaveBalance { get; set; } = 0;
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool GotUpdate { get; set; }
    }
}
