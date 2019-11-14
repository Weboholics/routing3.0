using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Routing_30.Models;

namespace Routing_30.Controllers
{
    public class Admin : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public Admin(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
