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
using TrainC1810L.Models.ModelView;
using Newtonsoft.Json;

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

        public async Task<IActionResult> ShowTrain(string routeto , int routefrom, DateTime setTodaysDate)
        {
            var tgian = DateTimeOffset.Now.ToUnixTimeSeconds();
            return View("SearchTrain", await _context.TrainRoute.Include(p => p.train).Include(p => p.station)
                .Where(t => t.train.RouteFromTo.Contains(routeto) && t.StationId==(routefrom) && t.DepartureTimeTo >= (setTodaysDate)).Take(6).ToListAsync());
        }

        public async Task<IActionResult> Showve(int ve)
        {
            //var idpass = from p in _context.passengers
            //             where (p.PNRno == ve)
            //             select new Ve
            //             {
            //                 Id = p.Id
            //             };
            var idpass = _context.passengers.Where(x => x.PNRno == ve).SingleOrDefault();
            
            var vexe = await (from bt in _context.bookingTickets
                                    join c in _context.chairs on bt.ChairId equals c.Id
                                    join p in _context.passengers on bt.PassengerId equals p.Id
                                    join cs in _context.compartments on c.CompartmentId equals cs.Id
                                    join t in _context.trains on cs.TrainId equals t.Id
                                    where (p.Id == idpass.Id)
                                    select new Bills
                                    {
                                        Id = p.Id,
                                        NamePass = p.Name,
                                        PNRNO = p.PNRno,
                                        Age = p.Age,
                                        Field = t.Field,
                                        TrainNo = t.TrainNo,
                                        Timefrom = t.DepartureTime,
                                        Seats = c.Seats,
                                        Status = bt.Status,
                                        Price = c.Price
                                    }).ToListAsync();
            if (vexe == null)
            {
                return NotFound();
            }
            return View(vexe);
        }
        public async Task<IActionResult> ResultSearch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var HomeResRult = await (from t in _context.trains
                                     join tr in _context.TrainRoute on t.Id equals tr.TrainId
                                     join c in _context.compartments on t.Id equals c.TrainId
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
                                     Total = c.Total,
                                     Range = tr.Range
                                 }).ToListAsync();
            if (HomeResRult == null)
            {
                return NotFound();
            }
            return View(HomeResRult);
        }

        [HttpPost]
        public IActionResult GetChair(int idchair)
        {
            var Query = (from c in _context.compartments
                         join cs in _context.chairs on c.Id equals cs.CompartmentId
                         where (c.Id == idchair)
                         select new Chairs
                         {
                             Seats = cs.Seats
                         }).ToList();
            if (Query == null)
            {
                //return BadRequest(Compart.Error.Message);
            }

            var chair = JsonConvert.SerializeObject(Query);
            return Content(chair, "application/json");
        }


        [HttpPost]
        public IActionResult CreatePassenger(string name, int age, bool Gender, int total, string Class, int price, int pnrno)
        {
            //new Passenger { Name = name, Age = age, Gender = gt, Total = total, Class = info }
            var passenger = new Passenger[]
            {
                new Passenger{ Name = name, Age = age, Gender = Gender,Total = total , Class = Class, PNRno = pnrno }
            };
            _context.passengers.AddRange(passenger);
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookChair(List<Chair> ChairList)
        {

            _context.chairs.AddRange(ChairList);
            await _context.SaveChangesAsync();
            int chairid = _context.chairs.Max(item => item.Id);
            int passid = _context.passengers.DefaultIfEmpty().Max(r => r == null ? 0 : r.Id);
            var bookings = new BookingTicket[]
            {
                new BookingTicket{PassengerId= passid ,ChairId= chairid}
            };
            _context.bookingTickets.AddRange(bookings);
            _context.SaveChanges();

            return Json(bookings);

        }

        public async Task<IActionResult> TicketBook()
        {
            int id = _context.passengers.DefaultIfEmpty().Max(r => r == null ? 0 : r.Id);
            var Bookticket = await (from bt in _context.bookingTickets
                                    join c in _context.chairs on bt.ChairId equals c.Id
                                    join p in _context.passengers on bt.PassengerId equals p.Id
                                    join cs in _context.compartments on c.CompartmentId equals cs.Id
                                    join t in _context.trains on cs.TrainId equals t.Id
                                     where (p.Id == id)
                                     select new Bills
                                     {
                                         Id = p.Id,
                                         NamePass = p.Name,
                                         PNRNO = p.PNRno,
                                         Age = p.Age,
                                         Field = t.Field,
                                         TrainNo = t.TrainNo,
                                         Timefrom = t.DepartureTime,
                                         Seats = c.Seats,
                                         Status = bt.Status,
                                         Price = c.Price
                                     }).ToListAsync();
            if (Bookticket == null)
            {
                return NotFound();
            }
            return View(Bookticket);
        }

    }
}
