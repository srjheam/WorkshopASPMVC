using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorkshopASPMVC.Services;

namespace WorkshopASPMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        public readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            ViewData["minDate"] = (minDate ?? result.OrderBy(x => x.Date).FirstOrDefault().Date).ToString("yyyy-MM-dd");
            ViewData["maxDate"] = (maxDate ?? DateTime.Now).ToString("yyyy-MM-dd");
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            ViewData["minDate"] = (minDate ?? result.SelectMany(groups => groups).OrderBy(x => x.Date).FirstOrDefault().Date).ToString("yyyy-MM-dd");
            ViewData["maxDate"] = (maxDate ?? DateTime.Now).ToString("yyyy-MM-dd");
            return View(result);
        }
    }
}
