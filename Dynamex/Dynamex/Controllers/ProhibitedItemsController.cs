using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamex.Controllers
{
    public class ProhibitedItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
