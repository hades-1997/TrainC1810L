using System;
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
    public class BookingTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookingTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookingTickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.bookingTickets.Include(b => b.chair).Include(b => b.passenger);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookingTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingTicket = await _context.bookingTickets
                .Include(b => b.chair)
                .Include(b => b.passenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookingTicket == null)
            {
                return NotFound();
            }

            return View(bookingTicket);
        }

        // GET: BookingTickets/Create
        public IActionResult Create()
        {
            ViewData["ChairId"] = new SelectList(_context.chairs, "Id", "Id");
            ViewData["PassengerId"] = new SelectList(_context.passengers, "Id", "Id");
            return View();
        }

        // POST: BookingTickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Status,PassengerId,ChairId")] BookingTicket bookingTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChairId"] = new SelectList(_context.chairs, "Id", "Id", bookingTicket.ChairId);
            ViewData["PassengerId"] = new SelectList(_context.passengers, "Id", "Id", bookingTicket.PassengerId);
            return View(bookingTicket);
        }

        // GET: BookingTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingTicket = await _context.bookingTickets.FindAsync(id);
            if (bookingTicket == null)
            {
                return NotFound();
            }
            ViewData["ChairId"] = new SelectList(_context.chairs, "Id", "Id", bookingTicket.ChairId);
            ViewData["PassengerId"] = new SelectList(_context.passengers, "Id", "Id", bookingTicket.PassengerId);
            return View(bookingTicket);
        }

        // POST: BookingTickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Status,PassengerId,ChairId")] BookingTicket bookingTicket)
        {
            if (id != bookingTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingTicketExists(bookingTicket.Id))
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
            ViewData["ChairId"] = new SelectList(_context.chairs, "Id", "Id", bookingTicket.ChairId);
            ViewData["PassengerId"] = new SelectList(_context.passengers, "Id", "Id", bookingTicket.PassengerId);
            return View(bookingTicket);
        }

        // GET: BookingTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingTicket = await _context.bookingTickets
                .Include(b => b.chair)
                .Include(b => b.passenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookingTicket == null)
            {
                return NotFound();
            }

            return View(bookingTicket);
        }

        // POST: BookingTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {      
            var x = (from c in _context.chairs
                     join bt in _context.bookingTickets on c.Id equals bt.ChairId
                     where (bt.Id == id)
                     select c).FirstOrDefault();

               _context.chairs.Remove(x);
            await _context.SaveChangesAsync();
          
            return RedirectToAction(nameof(Index));
        }

        private bool BookingTicketExists(int id)
        {
            return _context.bookingTickets.Any(e => e.Id == id);
        }
                
    }
}
