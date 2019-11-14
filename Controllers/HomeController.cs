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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string culture)
        {
            ActionResult result;
            if (culture == null)  // If no given culture - redirect to culture specific page
            {
                result = new RedirectResult(Url.Action("Index", "Home", new { culture ="sv-se"}));
            }
            else
            {
                result=View();
            }
            return result;
        }
    }
}
