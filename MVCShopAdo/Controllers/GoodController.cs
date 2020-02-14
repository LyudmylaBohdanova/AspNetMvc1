using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.Controllers
{
    public class GoodController : Controller
    {
        private ShopViewServices services;

        private const int itemsCount = 6;

        public GoodController(ShopViewServices services)
        {
            this.services = services;
        }

        public ActionResult Goods(int page = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(services.serviceGood.GetAll().Count() / (double)itemsCount);
            return View();
        }

        public ActionResult TableGoods(int id = 1)
        {
            var goods = services.serviceGood.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(goods);
        }

        public ActionResult EditGood(int id = 0)
        {
            GoodViewModel good = services.serviceGood.Get(id);
            ViewBag.Category = services.serviceCategory.GetAll().OrderBy(x => x.CategoryName);
            ViewBag.Manufacturer = services.serviceManufacturer.GetAll().OrderBy(x => x.ManufacturerName);

            if (id == 0)
                good = new GoodViewModel();

            return PartialView(good);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGood(GoodViewModel good, string action)
        {
            if (ModelState.IsValid)
            {
                if (action == "save")
                {
                    services.serviceGood.CreateOrUpdate(good);
                    TempData["Success"] = $"The category {good.GoodName} edit success!";
                }
                else if(action == "add")
                {
                    services.serviceGood.CreateOrUpdate(good);
                    TempData["Success"] = $"The category {good.GoodName} edit success!";
                }
                else if (action == "delete")
                {
                    services.serviceGood.Remove(good);
                    TempData["Success"] = $"The category {good.GoodName} delete success!";
                }
                return RedirectToAction("Goods", "Good");
            }

            TempData["Error"] = $"The category {good.GoodName} has action error!";
            return RedirectToAction("Goods", "Good");
        }
    }
}