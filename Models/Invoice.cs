namespace Realestate_ERP_Dashboard.Models;

public class Invoice
{
    public int Id { get; set; }

    public int Month { get; set; }
    public string Year { get; set; }
    public string? Unit_In_Build { get; set; }
    public int? ElectricityBill { get; set; }
    public int? WaterBill { get; set; }

    public int? BuildingId { get; set; }
    public Building Building { get; set; }
}
