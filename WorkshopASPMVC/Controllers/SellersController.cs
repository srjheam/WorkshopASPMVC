using Microsoft.AspNetCore.Mvc;

namespace WorkshopASPMVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
