using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HelloMVC.Data;
using HelloMVC.Models;
using HelloMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class MachinesController : Controller
    {
        //private static Machine m;
        //private static List<Machine> machines = new List<Machine>();
        private readonly AppDb db;
        private readonly IEnumerable<ILogWriter> logs;
        /*
        static MachinesController()
        {
            var y = new Machine();
            y.Id = 1;
            y.Name = "Machine A";
            y.TurnOn();
            machines.Add(y);

            var x1 = new Machine();
            x1.Name = "Machine B";
            x1.Id = 2;
            machines.Add(x1);
        }
        */
        public MachinesController(AppDb db,IEnumerable<ILogWriter> logs)
        {
            this.db = db;
            this.logs = logs;
        }

        // Startup.cs
        // {controller=Home}/{action=Action}/{id?}
        // Machine/Index/2
        public IActionResult Index(int id)
        {
            //m = null;
            //foreach (var item in machines)
            //{
            //    if (item.Id==id)
            //    {
            //        m = item;
            //        break;
            //    }
            //}
            /*
            m = machines.SingleOrDefault(x => x.Id == id);
            if (m == null)
            {
                m = machines[0];
            }
            */
            var m = db.Machines.Find(id);
            if (m == null) return NotFound();

            return View(m);
        }

        [Route("machines/add/{id}")]
        [HttpPost]
        public IActionResult InsertCoin(int id,decimal amount)
        {
            try
            {
                //var m = machines.SingleOrDefault(x => x.Id == id);
                //m.AcceptsCoin(amount);    
                var m = db.Machines.Find(id);
                if (m == null) return NotFound();
                m.AcceptsCoin(amount);
                db.SaveChanges();
                if (amount == 10)
                {
                    // alert to logfile
                    var s = $"{DateTime.Now:s} - {amount} THB has added.";
                    // 1.
                    //System.IO.File.AppendAllText("log.txt", s);

                    //2
                    //var log = new FileLogWriter();
                    //log.write(s);

                    //3
                    foreach (var log in logs)
                    {
                        //if (log is LineLogWriter)
                        //{
                        //
                        //}
                        log.write(s);
                    }
                }
            } catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction(nameof(Index), new { id });
        }

        [Route("machines/cancel/{id}")]
        [HttpPost]
        public IActionResult Cancel(string id)
        {
            //m.ReturnRemainingCoin();
            var m = db.Machines.Find(id);
            m.ReturnRemainingCoin();
            db.SaveChanges();

            if (m == null) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult TurnOn(int id)
        {
            //var m = machines.SingleOrDefault(x => x.Id == id);
            //m.TurnOn();
            var m = db.Machines.Find(id);
            m.TurnOn();
            db.SaveChanges();
            if (m == null) return NotFound();
            return RedirectToAction(nameof(Index) ,new { id  } );
        }

        [HttpPost]
        public IActionResult TurnOff(int id)
        {
            //var m = machines.SingleOrDefault(x => x.Id == id);
            var m = db.Machines.Find(id);
            if (m == null) return NotFound();
            m.TurnOff();
            db.SaveChanges();
            return RedirectToAction( nameof(Index), new { id });
        }
    }
}
