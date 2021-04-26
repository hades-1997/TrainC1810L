using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainC1810L.Models;
using TrainC1810L.Data;

namespace SpoorC1810L.Controllers
{
   // [Authorize]
    public class RailwaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RailwaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Railways
        public async Task<IActionResult> Index()
        {
            return View(await _context.Railway.ToListAsync());
        }

        // GET: Railways/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var railway = await _context.Railway
                .FirstOrDefaultAsync(m => m.Id == id);
            if (railway == null)
            {
                return NotFound();
            }

            return View(railway);
        }

        // GET: Railways/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Railways/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RailwayName")] Railway railway)
        {
            if (ModelState.IsValid)
            {
                _context.Add(railway);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(railway);
        }

        // GET: Railways/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var railway = await _context.Railway.FindAsync(id);
            if (railway == null)
            {
                return NotFound();
            }
            return View(railway);
        }

        // POST: Railways/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RailwayName")] Railway railway)
        {
            if (id != railway.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(railway);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RailwayExists(railway.Id))
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
            return View(railway);
        }

        // GET: Railways/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var railway = await _context.Railway
                .FirstOrDefaultAsync(m => m.Id == id);
            if (railway == null)
            {
                return NotFound();
            }

            return View(railway);
        }

        // POST: Railways/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var railway = await _context.Railway.FindAsync(id);
            _context.Railway.Remove(railway);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RailwayExists(int id)
        {
            return _context.Railway.Any(e => e.Id == id);
        }
    }
}
