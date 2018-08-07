using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        //public IRepository Repository { get;  } = TypeBroker.Repository;
        //public IRepository Repository { get; set; } = new MemoryRepository();
        // GET: /<controller>/
        private IRepository repository;
        private ProductTotalizer totalize;

        public HomeController(IRepository repo, ProductTotalizer total)
        {
            repository = repo;
            totalize = total;
        }

        public ViewResult Index()
        {
            ViewBag.Total = totalize.Repository.ToString();
            ViewBag.HomeController = repository.ToString();
            return View(repository.Products);
        }
    }
}
