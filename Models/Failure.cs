namespace Dashboard.Models
{
    public class Failure
    {
        public int FailureId { get; set; }
        public int EquipmentId { get; set; }
        public decimal Cost { get; set; }
        public int DowntimeHours { get; set; }
        public DateTime FailureDate { get; set; }

        public Equipment? Equipment { get; set; }
    }
}
