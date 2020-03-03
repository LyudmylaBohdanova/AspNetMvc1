using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCShopAdo.Controllers.WebApi
{
    public class ManufacturerController : ApiController
    {
        private ShopViewServices services;

        public ManufacturerController(ShopViewServices services)
        {
            this.services = services;
        }

        // GET: api/Manufacturer
        public IEnumerable<ManufacturerViewModel> Get()
        {
            return services.serviceManufacturer.GetAll();
        }

        // GET: api/Manufacturer/5
        public ManufacturerViewModel Get(int id)
        {
            return services.serviceManufacturer.Get(id);
        }

        // POST: api/Manufacturer
        public void Post([FromBody]ManufacturerViewModel value)
        {
            services.serviceManufacturer.CreateOrUpdate(value);
        }

        // PUT: api/Manufacturer/5
        public void Put(int id, [FromBody]ManufacturerViewModel value)
        {
            ManufacturerViewModel model = services.serviceManufacturer.GetAll().FirstOrDefault(x => x.ManufacturerId == id);
            if(model != null)
                model.ManufacturerName = value.ManufacturerName;
        }

        // DELETE: api/Manufacturer/5
        public void Delete(int id)
        {
            ManufacturerViewModel model = services.serviceManufacturer.GetAll().FirstOrDefault(x => x.ManufacturerId == id);
            if (model != null)
                services.serviceManufacturer.Remove(model);
        }
    }
}
