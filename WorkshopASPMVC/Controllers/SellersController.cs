﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WorkshopASPMVC.Models;
using WorkshopASPMVC.Models.ViewModels;
using WorkshopASPMVC.Services;

namespace WorkshopASPMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id is null" });
            }

            var seller = await _sellerService.FindAsync(id.Value);
            if (seller is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id is null" });
            }

            var seller = await _sellerService.FindAsync(id.Value);
            if (seller is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(seller);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id is null" });
            }

            var seller = await _sellerService.FindAsync(id.Value);
            if (seller is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var departments = await _departmentService.FindAllAsync();
            var sellerFormViewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(sellerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit), new { id });
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
