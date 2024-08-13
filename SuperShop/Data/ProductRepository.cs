using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SuperShop.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext) : base(dataContext)
        {

            _dataContext = dataContext;
        }


        public IQueryable GetAllWithUsers()
        {

            return _dataContext.Products.Include(p => p.User);

        }

        public IEnumerable<SelectListItem> GetComboProducts()
        {
            var list = _dataContext.Products.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();


            list.Insert(0, new SelectListItem
            {
                Text = "(Select a product...)",
                Value = "0"
            });

            return list;

        }
    }
}
