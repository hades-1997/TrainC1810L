using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpoorC1810L.Data;
using SpoorC1810L.Models;

namespace SpoorC1810L.Controllers
{
    public class TrainRoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainRoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrainRoutes
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = await _context.TrainRoute.Include(t => t.station).Include(t => t.train).ToListAsync();

            return View(applicationDbContext);
        }

        // GET: TrainRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainRoute = await _context.TrainRoute
                .Include(t => t.station)
                .Include(t => t.train)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainRoute == null)
            {
                return NotFound();
            }

            return View(trainRoute);
        }

        // GET: TrainRoutes/Create
        public IActionResult Create()
        {
            ViewData["StationId"] = new SelectList(_context.stations, "Id", "Id");
            ViewData["TrainId"] = new SelectList(_context.trains, "Id", "Id");
            return View();
        }

        // POST: TrainRoutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StationId,TrainId,DepartureTimeTo,Range")] TrainRoute trainRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StationId"] = new SelectList(_context.stations, "Id", "Id", trainRoute.station.Name);
            ViewData["TrainId"] = new SelectList(_context.trains, "Id", "Id", trainRoute.TrainId);
            return View(trainRoute);
        }

        // GET: TrainRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainRoute = await _context.TrainRoute.FindAsync(id);
            if (trainRoute == null)
            {
                return NotFound();
            }
            ViewData["StationId"] = new SelectList(_context.stations, "Id", "Id", trainRoute.StationId);
            ViewData["TrainId"] = new SelectList(_context.trains, "Id", "Id", trainRoute.TrainId);
            return View(trainRoute);
        }

        // POST: TrainRoutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StationId,TrainId,DepartureTimeTo,Range")] TrainRoute trainRoute)
        {
            if (id != trainRoute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainRouteExists(trainRoute.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StationId"] = new SelectList(_context.stations, "Id", "Id", trainRoute.StationId);
            ViewData["TrainId"] = new SelectList(_context.trains, "Id", "Id", trainRoute.TrainId);
            return View(trainRoute);
        }

        // GET: TrainRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainRoute = await _context.TrainRoute
                .Include(t => t.station)
                .Include(t => t.train)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainRoute == null)
            {
                return NotFound();
            }

            return View(trainRoute);
        }

        // POST: TrainRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainRoute = await _context.TrainRoute.FindAsync(id);
            _context.TrainRoute.Remove(trainRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainRouteExists(int id)
        {
            return _context.TrainRoute.Any(e => e.Id == id);
        }
    }
}
