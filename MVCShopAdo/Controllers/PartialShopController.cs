using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.Controllers
{
    public class PartialShopController : Controller
    {
        private ShopViewServices services;

        private const int itemsCount = 6;

        public PartialShopController(ShopViewServices services)
        {
            this.services = services;
        }

        public ActionResult TableGoods(int id = 1)
        {
            var goods = services.serviceGood.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(goods);
        }
        
        public ActionResult TableCategories(int id = 1)
        {
            var categories = services.serviceCategory.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(categories);
        }
        
        public ActionResult TableManufacturers(int id = 1)
        {
            var manufacturers = services.serviceManufacturer.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(manufacturers);
        }
    }
}