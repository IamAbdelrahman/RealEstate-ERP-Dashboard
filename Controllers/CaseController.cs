using Microsoft.AspNetCore.Mvc;

namespace Realestate_ERP_Dashboard.Controllers
{
    public class CaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
