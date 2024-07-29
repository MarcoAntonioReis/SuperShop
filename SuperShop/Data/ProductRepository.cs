using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using System.Linq;

namespace SuperShop.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext dataContext;

        public ProductRepository(DataContext dataContext) : base(dataContext)
        {

            this.dataContext = dataContext;
        }


        public IQueryable GetAllWithUsers() {

            return dataContext.Products.Include(p => p.User);

        }

    }
}
