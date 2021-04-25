
using Microsoft.AspNetCore.Mvc;
using SpoorC1810L.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpoorC1810L.Controllers
{
    public class ViewsTraincontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
