using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopASPMVC.Data;
using WorkshopASPMVC.Models;

namespace WorkshopASPMVC.Services
{
    public class SalesRecordService
    {
        private readonly WorkshopContext _context;

        public SalesRecordService(WorkshopContext context)
        {
            _context = context;
        }

        public async Task<ICollection<SalesRecord>> FindByDateAsync(DateTime? min, DateTime? max)
        {
            IQueryable<SalesRecord> query = _context.SalesRecord;
            if (min.HasValue)
            {
                query = query.Where(x => x.Date >= min.Value);
            }
            if (max.HasValue)
            {
                query = query.Where(x => x.Date <= max.Value);
            }

            return await query
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<ICollection<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? min, DateTime? max)
        {
            IQueryable<SalesRecord> query = _context.SalesRecord;
            if (min.HasValue)
            {
                query = query.Where(x => x.Date >= min.Value);
            }
            if (max.HasValue)
            {
                query = query.Where(x => x.Date <= max.Value);
            }

            return (await query
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync())
                .GroupBy(x => x.Seller.Department)
                .ToList();
        }
    }
}
