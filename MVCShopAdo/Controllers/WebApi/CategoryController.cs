using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCShopAdo.WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        private ShopViewServices services;

        public CategoryController(ShopViewServices services)
        {
            this.services = services;
        }

        // GET: api/ValuesCategory
        public IEnumerable<CategoryViewModel> Get()
        {
            return services.serviceCategory.GetAll();
        }

        // GET: api/ValuesCategory/5
        public CategoryViewModel Get(int id)
        {
            return services.serviceCategory.Get(id);
        }

        // POST: api/ValuesCategory
        public CategoryViewModel Post([FromBody]CategoryViewModel value)
        {
            return services.serviceCategory.CreateOrUpdate(value);
        }

        // PUT: api/ValuesCategory/5
        public void Put(int id, [FromBody]CategoryViewModel value)
        {
            CategoryViewModel model = services.serviceCategory.GetAll().FirstOrDefault(x => x.CategoryId == id);
            if (model != null)
                model.CategoryName = value.CategoryName;
        }

        // DELETE: api/ValuesCategory/5
        public void Delete(int id)
        {
            CategoryViewModel model = services.serviceCategory.GetAll().FirstOrDefault(x => x.CategoryId == id);
            if (model != null)
                services.serviceCategory.Remove(model);
        }
    }
}
