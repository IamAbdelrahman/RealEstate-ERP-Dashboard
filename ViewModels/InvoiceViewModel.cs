namespace Realestate_ERP_Dashboard.ViewModels
{
    public class InvoiceViewModel
    {
        public string SelectedBuilding { get; set; }
        public List<string> BuildingList { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public string UnitName { get; set; }

        public decimal ElectricityBill { get; set; }
        public decimal WaterBill { get; set; }

        // For display only
        public decimal TotalElectricityBill => ElectricityBill;
        public decimal TotalWaterBill => WaterBill;
    }
}
