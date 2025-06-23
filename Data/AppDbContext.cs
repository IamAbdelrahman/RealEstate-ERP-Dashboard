using Microsoft.EntityFrameworkCore;
using Realestate_ERP_Dashboard.Models;

namespace Realestate_ERP_Dashboard.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Building> Buildings { get; set; }

}
