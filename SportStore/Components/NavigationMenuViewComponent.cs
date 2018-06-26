using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models;

namespace SportStore.Components
{
    public class NavigationMenuViewComponent: ViewComponent
    {
        IProductRepository productRepository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            productRepository = repository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(productRepository.Products.Select(p => p.Category).Distinct().OrderBy(p => p));
        }
    }
}
