using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
       // [Route("myroute")]
        //[Route("[controller]/MyIndex")]
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });
        }

        public ViewResult CustomVariable(string id)
        {
            Result result = new Result {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            };
            //result.Data["Id"] = RouteData.Values["id"];
            result.Data["Id"] = id;
            return View("Result", result);
        }
    }
}
