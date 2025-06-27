using Microsoft.AspNetCore.Mvc;
using Realestate_ERP_Dashboard.Models;

namespace Realestate_ERP_Dashboard.Controllers
{
    public class CaseController : Controller
    {
        public IActionResult Index()
        {
            var cases = new List<Case>
            {
                new Case {Id = 1 , CaseNumber="1234"},
                new Case {Id = 2 , CaseNumber="5678" } 
            };
            return View("Index",cases);
        }
    }
}
