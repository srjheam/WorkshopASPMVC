using Microsoft.AspNetCore.Mvc;
using WorkshopASPMVC.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _service.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
