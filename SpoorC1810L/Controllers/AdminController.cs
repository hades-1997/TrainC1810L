﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpoorC1810L.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainC1810L.Data;
using TrainC1810L.Interfaces;
using TrainC1810L.Models;
using TrainC1810L.Models.ModelView;

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
            var applicationDbContext = await _context.TrainRoute.Include(t => t.station).Include(t => t.train).ToListAsync();

            return View(applicationDbContext);
        }
        public async Task<IActionResult> Booking(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var booking = await (from tr in _context.TrainRoute
                                 join t in _context.trains on tr.TrainId equals t.Id
                                 join s in _context.stations on tr.StationId equals s.Id
                                 join c in _context.compartments on t.Id equals c.TrainId
                                 //join cr in _context.chairs on c.Id equals cr.CompartmentId
                                 where (t.Id == id)
                                 select new Books
                                 {
                                     Id = c.Id,
                                     TrainId = c.TrainId,
                                     Field = t.Field,
                                     TrainNo = t.TrainNo,
                                     TrainName = t.TrainName,
                                     RouteFromTo = t.RouteFromTo,
                                     DepartureTime = t.DepartureTime,
                                     Toa = c.Toa,
                                     Numcloums = c.Numcloums,
                                     Numrows = c.Numrows,
                                     Total = c.Total
                                 }).ToListAsync();
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpPost]
        public IActionResult GetCompart(int id)
        {

            var Compart = (from tr in _context.TrainRoute
                                join t in _context.trains on tr.TrainId equals t.Id
                                join s in _context.stations on tr.StationId equals s.Id
                                join c in _context.compartments on t.Id equals c.TrainId
                                join cr in _context.chairs on c.Id equals cr.CompartmentId
                                where (c.Id == id)
                                select new Books
                                {
                                    Id = c.Id,
                                    Toa = c.Toa,
                                    Numcloums = c.Numcloums,
                                    Numrows = c.Numrows,
                                    Total = c.Total,
                                    //NameCr = cr.Sign
                                }).ToList();
            if (Compart == null)
            {
                //return BadRequest(Compart.Error.Message);
            }

            var serialized = JsonConvert.SerializeObject(Compart);
            return Content(serialized, "application/json");
            //var Compart = _context.compartments.FirstOrDefaultAsync(m => m.Id == id);

            //return Json(new
            //{ 
            //    Id = Compart
            //});
        }


      
        public IActionResult CreateBookChair()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBookChair(Chair chair)
        {

            return View();
        }
    }
}