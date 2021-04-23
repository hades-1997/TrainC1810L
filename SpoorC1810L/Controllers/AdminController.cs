using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpoorC1810L.Controllers;
using SpoorC1810L.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainC1810L.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public AdminController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.TrainRoute.Include(p => p.train).Include(p => p.station).ToListAsync();
            return View(applicationDbContext);
        }
        public async Task<IActionResult> Booking(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.TrainRoute
                .Include(t => t.station)
                .Include(t => t.train)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
    }
}
