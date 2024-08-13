using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using SuperShop.Data.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace SuperShop.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboProducts();
    }
}
