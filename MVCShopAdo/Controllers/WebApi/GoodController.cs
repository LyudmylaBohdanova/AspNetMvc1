using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCShopAdo.Controllers.WebApi
{
    public class GoodController : ApiController
    {
        private ShopViewServices services;

        public GoodController(ShopViewServices services)
        {
            this.services = services;
        }

        // GET: api/Good
        public IEnumerable<GoodViewModel> Get()
        {
            return services.serviceGood.GetAll();
        }

        // GET: api/Good/5
        public GoodViewModel Get(int id)
        {
            return services.serviceGood.Get(id);
        }

        // POST: api/Good
        public void Post([FromBody]GoodViewModel value)
        {
            services.serviceGood.CreateOrUpdate(value);
        }

        // PUT: api/Good/5
        public void Put(int id, [FromBody]GoodViewModel value)
        {
            GoodViewModel model = services.serviceGood.GetAll().FirstOrDefault(x => x.GoodId == id);
            if(model != null)
            {
                model.CategoryId = value.CategoryId;
                model.CategoryName = value.CategoryName;
                model.GoodCount = value.GoodCount;
                model.GoodName = value.GoodName;
                model.ManufacturerId = value.ManufacturerId;
                model.ManufacturerName = value.ManufacturerName;
                model.Price = value.Price;
            }
        }

        // DELETE: api/Good/5
        public void Delete(int id)
        {
            GoodViewModel model = services.serviceGood.GetAll().FirstOrDefault(x => x.GoodId == id);
            if (model != null)
                services.serviceGood.Remove(model);
        }
    }
}
