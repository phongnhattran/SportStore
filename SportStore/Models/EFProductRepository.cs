using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
   
        public EFProductRepository(ApplicationDbContext appContext)
        {
            context = appContext;
        }
        public IQueryable<Product> Products => context.Products;
    }
}
