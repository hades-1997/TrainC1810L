﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainC1810L.Data;
using TrainC1810L.Models;

namespace TrainC1810L.Controllers
{
    [Authorize]
    public class CompartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Compartments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.compartments.Include(c => c.trains);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Compartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartment = await _context.compartments
                .Include(c => c.trains)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compartment == null)
            {
                return NotFound();
            }

            return View(compartment);
        }

        // GET: Compartments/Create
        public IActionResult Create()
        {
            ViewData["TrainId"] = new SelectList(_context.trains, "Id", "Id");
            return View();
        }

        // POST: Compartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Toa,Numrows,Numcloums,Total,TrainId")] Compartment compartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainId"] = new SelectList(_context.trains, "Id", "Id", compartment.TrainId);
            return View(compartment);
        }

        // GET: Compartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartment = await _context.compartments.FindAsync(id);
            if (compartment == null)
            {
                return NotFound();
            }
            ViewData["TrainId"] = new SelectList(_context.trains, "Id", "Id", compartment.TrainId);
            return View(compartment);
        }

        // POST: Compartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Toa,Numrows,Numcloums,Total,TrainId")] Compartment compartment)
        {
            if (id != compartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompartmentExists(compartment.Id))
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
            ViewData["TrainId"] = new SelectList(_context.trains, "Id", "Id", compartment.TrainId);
            return View(compartment);
        }

        // GET: Compartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartment = await _context.compartments
                .Include(c => c.trains)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compartment == null)
            {
                return NotFound();
            }

            return View(compartment);
        }

        // POST: Compartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compartment = await _context.compartments.FindAsync(id);
            _context.compartments.Remove(compartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompartmentExists(int id)
        {
            return _context.compartments.Any(e => e.Id == id);
        }
    }
}
