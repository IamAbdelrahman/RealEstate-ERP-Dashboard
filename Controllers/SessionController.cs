using Microsoft.AspNetCore.Mvc;

namespace Realestate_ERP_Dashboard.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
