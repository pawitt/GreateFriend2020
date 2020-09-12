using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloMVC.Models;
using HelloMVC.Class;
using Microsoft.Extensions.Configuration;
using Rotativa.AspNetCore;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            this.config = config;
        }

        // ActionResult => ViewReult,JSonResult
        public IActionResult Index()
        {
            ViewBag.Number = config["number"];


            int x = 55; // System.Int32 other etc, System.Double
            var y = 55.0;
            var foo = new Foo();
            var result = foo.Bar(3.2, 2);
            ViewBag.result = result;

            var C1 = new Counter();
            C1.Count = C1.Count + 1;

            
            GC.Collect();  // microsoft not recommend
            
            return View(); // <= helper method
            // or this
            // var r = new ViewResult();
            // return r;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        // ? is define optional
        [Route("map/{branch?}")]
        public IActionResult Map(string branch="HQ") // ="HQ" is set default value
        {
            ViewBag.Branch = branch;
            //return View();

            //using rotativa return as pdf
            var r = new ViewAsPdf();
            r.ViewData = ViewData;
            return r;
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
