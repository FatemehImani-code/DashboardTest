namespace Dashboard.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;

        public ICollection<Failure>? Failures { get; set; }
    }
}
