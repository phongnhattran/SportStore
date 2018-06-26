using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository repository;
        public int pageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }
        public ViewResult List(string category, int productPage = 1) => View(new ProductsListViewModel
        {
            Products = repository.Products.Where(p => p.Category == category || category == null)
                                            .OrderBy(p => p.ProductID)
                                            .Skip((productPage - 1) * pageSize)
                                            .Take(pageSize),
            PagingInfo = new PagingInfo { CurrentPage = productPage, ItemsPerPage = pageSize,
                                          TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(p => p.Category == category).Count() },
            CurrentCategory = category
        });
    }
}