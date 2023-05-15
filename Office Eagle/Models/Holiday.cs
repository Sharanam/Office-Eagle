namespace Office_Eagle.Models
{
    public class Holiday
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int NoOfDays { get; set; }
        public bool IsOptional { get; set; }
    }
}
