using MVCShopAdo.Models;
using BLL.DTO;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCShopAdo.Controllers
{
    public class ShopController : Controller
    {
        private ShopViewServices services;

        private const int itemsCount = 6;

        public ShopController(ShopViewServices services)
        {
            this.services = services;
        }
        public ActionResult Goods(int page = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(services.serviceGood.GetAll().Count() / (double)itemsCount);
            return View();
        }
        
        public ActionResult Categories(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(services.serviceCategory.GetAll().Count() / (double)itemsCount);
            return View();
        }
        
        public ActionResult Manufacturer(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(services.serviceManufacturer.GetAll().Count() / (double)itemsCount);
            return View();
        }
    }
}