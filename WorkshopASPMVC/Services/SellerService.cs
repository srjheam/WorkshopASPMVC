using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WorkshopASPMVC.Data;
using WorkshopASPMVC.Models;
using WorkshopASPMVC.Services.Exceptions;

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

        public Seller Find(int id) =>
            _context.Seller.Include(x => x.Department).FirstOrDefault(x => x.Id == id);

        public void Remove(int id)
        {
            var seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
