using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopASPMVC.Models;

namespace WorkshopASPMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            var departments = new List<Department>();
            departments.Add(new Department { Id = 1, Name = "Eletronics" });
            departments.Add(new Department { Id = 2, Name = "Toys" });

            return View(departments);
        }
    }
}
