using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpoorC1810L.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainC1810L.Data;
using TrainC1810L.Interfaces;
using TrainC1810L.Models;
using TrainC1810L.Models.ModelView;

namespace TrainC1810L.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private const string SessionChair = "SessionChair";

        public AdminController(ILogger<HomeController> logger, ApplicationDbContext context, 
            RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var admin = await (from b in _context.Bill
                               join bk in _context.bookingTickets on b.BookingTicketID equals bk.Id
                               join p in _context.passengers on bk.PassengerId equals p.Id
                               select new Admin
                               {
                                   Namepass = p.Name,
                                   Age = p.Age,
                                   PNRno = p.PNRno,
                                   Gender = p.Gender,
                                   MoneyReceived = b.MoneyReceived,
                                   Refunds = b.Refunds,

                               }).ToListAsync();
            return View(admin);
        }
        public async Task<IActionResult> datve()
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
            var booking = await (from t in _context.trains
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
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpPost]
        public IActionResult GetCompart(int id)
        {

            var Compart = (from c in _context.compartments

                           where (c.Id == id)
                           select new Books
                           {
                               Id = c.Id,
                               Toa = c.Toa,
                               Total = c.Total
                           }).ToList();
            if (Compart == null)
            {
                //return BadRequest(Compart.Error.Message);
            }

            var serialized = JsonConvert.SerializeObject(Compart);
            return Content(serialized, "application/json");
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
                new Passenger{  Name = name, Age = age, Gender = Gender,Total = total , Class = Class, PNRno = pnrno }
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
                new BookingTicket{PassengerId= passid ,ChairId= chairid,Status = false}
            };
            _context.bookingTickets.AddRange(bookings);
            _context.SaveChanges();
            return Json(bookings);

        }

        public IActionResult Bill(int id)
        {
            var IdBooking = _context.bookingTickets.FindAsync(id);
            var query = (from bk in _context.bookingTickets
                         join c in _context.chairs on bk.ChairId equals c.Id
                         join p in _context.passengers on bk.PassengerId equals p.Id
                         join cp in _context.compartments on c.CompartmentId equals cp.Id
                         join t in _context.trains on cp.TrainId equals t.Id
                         where (bk.Id == id)
                         select new Booking
                         {
                             Id = bk.Id,
                             Field = t.Field,
                             TraiNo = t.TrainNo,
                             NamePasser = p.Name,
                             Price = c.Price * p.Total,
                             TotalChair = p.Total,
                             PassengerId = bk.PassengerId,
                             ChairId = bk.ChairId
                         }).ToList();

            return View(query);
        }
        [HttpPost]
        public async Task<IActionResult> Ticket(int BookingTicketID, int chairId, int passengerId)
        {
            //Id = BookingTicketID,Price = 0,ChairId =chairId, PassengerId =  passengerId, Status = true
            var Booking = new BookingTicket[]
            {
                new BookingTicket{Id = BookingTicketID,Price = 0,ChairId = chairId, PassengerId =  passengerId, Status = true}
            };

            _context.bookingTickets.UpdateRange(Booking);
            await _context.SaveChangesAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BillResult(int MoneyReceived, int Refunds, int BookingTicketID)
        {


            //MoneyReceived = MoneyReceived, Refunds = Refunds,TotalMoney=0, BookingTicketID = BookingTicketID
            var bills = new Bill[]
            {
                new Bill{MoneyReceived = MoneyReceived, Refunds = Refunds,TotalMoney=0, BookingTicketID = BookingTicketID}
            };
            _context.Bill.AddRange(bills);
            await _context.SaveChangesAsync();
            return Json(bills);
        }

        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(ProjectRole roles)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roles.RoleName);
            if (!roleExist)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roles.RoleName));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListUser()
        {
            var users = await (from u in _userManager.Users
                         join ur in _context.UserRoles on u.Id equals ur.UserId
                         join r in _roleManager.Roles on ur.RoleId equals r.Id
                         select new ApplicationUser
                         {
                             Id = u.Id,
                             UserName = u.UserName,
                             Email = u.Email,
                             Name = r.Name,
                             EmailConfirmed = u.EmailConfirmed
                         }).ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> UpdateEmail(string id)
        {
            var ApUser = await _userManager.FindByIdAsync(id);
            if (ApUser != null)
            {
                ApUser.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(ApUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUser");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }

    }
}
