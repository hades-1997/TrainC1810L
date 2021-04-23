using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpoorC1810L.Data;
using SpoorC1810L.Models;

namespace TrainC1810L.Controllers
{
    public class FaresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fares
        public async Task<IActionResult> Index()
        {
            return View(await _context.fares.ToListAsync());
        }

        // GET: Fares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fare = await _context.fares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fare == null)
            {
                return NotFound();
            }

            return View(fare);
        }

        // GET: Fares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Distance,TypeOfCompartment,TypeOfTrain")] Fare fare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fare);
        }

        // GET: Fares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fare = await _context.fares.FindAsync(id);
            if (fare == null)
            {
                return NotFound();
            }
            return View(fare);
        }

        // POST: Fares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Distance,TypeOfCompartment,TypeOfTrain")] Fare fare)
        {
            if (id != fare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FareExists(fare.Id))
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
            return View(fare);
        }

        // GET: Fares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fare = await _context.fares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fare == null)
            {
                return NotFound();
            }

            return View(fare);
        }

        // POST: Fares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fare = await _context.fares.FindAsync(id);
            _context.fares.Remove(fare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FareExists(int id)
        {
            return _context.fares.Any(e => e.Id == id);
        }
    }
}
