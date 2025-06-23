using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Realestate_ERP_Dashboard.Data;
using Realestate_ERP_Dashboard.Models;
using Realestate_ERP_Dashboard.ViewModels;

namespace Realestate_ERP_Dashboard.Controllers;

public class InvoicesController : Controller
{
    private readonly AppDbContext _appDbContext;

    public InvoicesController(AppDbContext appDbContext)
    {
        _appDbContext=appDbContext;
    }

    public IActionResult Index(int page = 1, int pageSize = 6, string searchString = "")
    {
        // For demo: show 1 static invoice

        var query = _appDbContext.Invoices
          .Include(i => i.Building)
          .AsQueryable();

        //if (!string.IsNullOrEmpty(searchString))
        //{
        //    invoicesQuery = invoicesQuery
        //                 .Where(i => i.ToLower().Contains(searchString.ToLower()));
        //}

        var invoices = query
          .OrderBy(i => i.Id)
          .Skip((page - 1) * pageSize)
          .Take(pageSize)
          .Select(i => new InvoiceViewModel
          {
              Id = i.Id,
              Month = i.Month,
              Year = i.Year,
              UnitName = i.Unit_In_Build,
              ElectricityBill = i.ElectricityBill ?? 0,
              WaterBill = i.WaterBill ?? 0,
              BuildingId = i.BuildingId,
          })
          .ToList();

        var totalItems = query.Count();
        var itemsToShow = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.CurrentPage = page;
        ViewBag.PageSize = pageSize;
        ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        return View("Index", itemsToShow);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var viewModel = new InvoiceViewModel
        {
            Buildings = _appDbContext.Buildings.ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(InvoiceViewModel model)
    {
        if (ModelState.IsValid)
        {
            var invoice = new Invoice
            {
                Month = model.Month,
                Year = model.Year,
                Unit_In_Build = model.UnitName,
                ElectricityBill = model.ElectricityBill,
                WaterBill = model.WaterBill,
                BuildingId = model.BuildingId
            };

            _appDbContext.Invoices.Add(invoice);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        // If validation fails, refill building list and return view
        model.Buildings = _appDbContext.Buildings.ToList();
        return View("Create", model);
    }


    public IActionResult Edit(int id)
    {
        var invoice = _appDbContext.Invoices.FirstOrDefault(c => c.Id==id);
        if (invoice == null)
            return NotFound();

        var editInvoice = new InvoiceViewModel
        {
            Month = invoice.Month,
            Year = invoice.Year,
            UnitName = invoice.Unit_In_Build,
            ElectricityBill = invoice.ElectricityBill,
            WaterBill = invoice.WaterBill,

            Buildings = _appDbContext.Buildings.ToList()
        };

        return View("Edit", editInvoice);
    }

    [HttpPost]
    public IActionResult Edit(InvoiceViewModel model)   //fix bug fill data
    {
        //var invoice = new Invoice();

        if (!ModelState.IsValid)
        {
            model.Buildings = _appDbContext.Buildings.ToList();
            return View(model);
        }

        var invoice = _appDbContext.Invoices.Find(model.Id);

        if (invoice == null)
            return NotFound();

        invoice.Month = model.Month;
        invoice.Year = model.Year;
        invoice.Unit_In_Build = model.UnitName;
        invoice.ElectricityBill = model.ElectricityBill;
        invoice.WaterBill = model.WaterBill;
        invoice.BuildingId = model.BuildingId;

        _appDbContext.SaveChanges();

        return RedirectToAction("Index");
    }

}
