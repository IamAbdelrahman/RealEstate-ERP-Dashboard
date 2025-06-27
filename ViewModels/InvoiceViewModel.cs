using Realestate_ERP_Dashboard.Models;

namespace Realestate_ERP_Dashboard.ViewModels;

public class InvoiceViewModel
{
    public int Id { get; set; }
    public int Month { get; set; }
    public string Year { get; set; }
    public string? UnitName { get; set; }
    public int? ElectricityBill { get; set; }
    public int? WaterBill { get; set; }

    // For display only
    //public decimal TotalElectricityBill => ElectricityBill;
    //public decimal TotalWaterBill => WaterBill;

    public int? BuildingId { get; set; }
    public List<Building>? Buildings { get; set; }
}
