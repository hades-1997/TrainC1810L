using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TrainC1810L.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrainC1810L.Data;

namespace SpoorC1810L.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.TrainRoute.Include(p => p.train).Include(p => p.station).Take(6).ToListAsync();
            return View(applicationDbContext);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SearchTrain()
        {
            return View();
        }

        //POST/home/showtrain

        public async Task<IActionResult> ShowTrain(string routeto , int routefrom)
        {
              
            return View("SearchTrain", await _context.TrainRoute.Include(p => p.train).Include(p => p.station)
                .Where(t => t.train.RouteFromTo.Contains(routeto) && t.StationId==(routefrom))
                .Take(6).ToListAsync());
        }
    }
}
