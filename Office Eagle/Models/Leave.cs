namespace Office_Eagle.Models
{
    public class Leave
    {
        public string Id { get; set; }
        public User Employee { get; set; }
        public string LeaveType { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Note { get; set; }
        public int WorkingDays { get; set; }
        public string Status { get; set; }
        public bool IsHalfDay { get; set; }
        public string HalfDayType { get; set; }
        public string ManagerComment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
