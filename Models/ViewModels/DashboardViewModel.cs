namespace Dashboard.Models.ViewModels
{
    public class DashboardViewModel
    {
        public string Equipment { get; set; } = "";
        public int TotalFailures { get; set; }
        public double TotalDowntime { get; set; }
        public decimal TotalCost { get; set; }
    }
}
