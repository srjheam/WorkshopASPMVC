using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Department>> FindAllAsync() =>
            await _context.Department.OrderBy(x => x.Name).ToListAsync();
    }
}
