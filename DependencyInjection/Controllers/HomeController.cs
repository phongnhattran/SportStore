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

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }
    }
}
