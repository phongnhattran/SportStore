using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService timer;
        private ILogger<HomeController> logger;
        public HomeController(UptimeService uptimeService, ILogger<HomeController> log)
        {
            timer = uptimeService;
            logger = log;
        }
        public ViewResult Index(bool throwException=false)
        {
            logger.LogDebug($"Handled {Request.Path} at uptime {timer.Uptime}");
            if (throwException)
            {
                throw new System.NullReferenceException();
            }
            return View(new Dictionary<string, string> { ["Message"] = "This is the Index action", ["Uptime"] = $"{timer.Uptime}ms" });
        }

        public ViewResult Error() => View(nameof(Index), new Dictionary<string, string>() { ["Message"] = "This is the Error action" });
        
    }
}
