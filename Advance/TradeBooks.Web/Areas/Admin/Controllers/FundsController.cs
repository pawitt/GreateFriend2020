using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TradeBooks.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FundsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
