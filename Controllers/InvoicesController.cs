using Microsoft.AspNetCore.Mvc;
using Realestate_ERP_Dashboard.ViewModels;

namespace Realestate_ERP_Dashboard.Controllers
{
    public class InvoicesController : Controller
    {
        public IActionResult Index()
        {
            // For demo: show 1 static invoice
            var invoices = new List<InvoiceViewModel>
        {
            new InvoiceViewModel
            {
                SelectedBuilding = "Building A",
                Month = 6,
                Year = 2025,
                UnitName = "Unit 101",
                ElectricityBill = 450,
                WaterBill = 120
            }
        };
            return View(invoices);
        }

        private List<string> GetBuildings()
        {
            return new List<string> { "عقار السالمية", "عقار 2", "عقار 3" };
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new InvoiceViewModel
            {
                BuildingList = GetBuildings()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(InvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save invoice to database (mock or real)
                TempData["Success"] = "Invoice saved successfully!";
                return RedirectToAction("Index");
            }

            model.BuildingList = GetBuildings(); // refill dropdown
            return View(model);
        }


    }
}
