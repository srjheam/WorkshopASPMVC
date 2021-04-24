using Microsoft.AspNetCore.Mvc;
using WorkshopASPMVC.Services;

namespace WorkshopASPMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _service;

        public SellersController(SellerService sellerService)
        {
            _service = sellerService;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }
    }
}
