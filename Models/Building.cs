namespace Realestate_ERP_Dashboard.Models;

public class Building
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Invoice>? Invoices { get; set; }
}
