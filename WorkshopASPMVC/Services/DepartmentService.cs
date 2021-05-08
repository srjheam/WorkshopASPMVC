using System.Collections.Generic;
using System.Linq;
using WorkshopASPMVC.Data;
using WorkshopASPMVC.Models;

namespace WorkshopASPMVC.Services
{
    public class DepartmentService
    {
        private readonly WorkshopContext _context;

        public DepartmentService(WorkshopContext context)
        {
            _context = context;
        }

        public List<Department> FindAll() =>
            _context.Department.OrderBy(x => x.Name).ToList();
    }
}
