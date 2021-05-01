using System.Collections.Generic;
using System.Linq;
using WorkshopASPMVC.Data;
using WorkshopASPMVC.Models;

namespace WorkshopASPMVC.Services
{
    public class SellerService
    {
        private readonly WorkshopContext _context;

        public SellerService(WorkshopContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll() =>
            _context.Seller.ToList();

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
