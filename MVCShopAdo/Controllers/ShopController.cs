using MVCShopAdo.Models;
using MVCShopAdo.ServicesView;
using Ninject;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCShopAdo.Controllers
{
    public class ShopController : Controller
    {
        private IViewService<GoodView> serviceGood;
        private IViewService<CategoryView> serviceCategory;
        private IViewService<ManufacturerView> serviceManufacturer;
        private const int itemsCount = 6;

        public ShopController(IViewService<GoodView> serviceGood, IViewService<CategoryView> serviceCategory,
            IViewService<ManufacturerView> serviceManufacturer)
        {
            this.serviceGood = serviceGood;
            this.serviceCategory = serviceCategory;
            this.serviceManufacturer = serviceManufacturer;
        }
        public ActionResult Goods(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(serviceGood.GetAll().Count() / (double)itemsCount);
            return View();
        }
        public ActionResult TableGoods(int id = 1)
        {
            var goods = serviceGood.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(goods);
        }
        public ActionResult Categories(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(serviceCategory.GetAll().Count() / (double)itemsCount);
            return View();
        }
        public ActionResult TableCategories(int id = 1)
        {
            var categories = serviceCategory.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(categories);
        }
        public ActionResult Manufacturer(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(serviceManufacturer.GetAll().Count() / (double)itemsCount);
            return View();
        }
        public ActionResult TableManufacturers(int id = 1)
        {
            var manufacturers = serviceManufacturer.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(manufacturers);
        }
        public ActionResult DeleteGoods(int id)
        {
            GoodView good = serviceGood.Get(id);
            serviceGood.Remove(good);
            return RedirectToAction("Goods");
        }
        public ActionResult DeleteCategories(int id)
        {
            CategoryView category = serviceCategory.Get(id);
            serviceCategory.Remove(category);
            return RedirectToAction("Categories");
        }
        public ActionResult DeleteManufacturer(int id)
        {
            ManufacturerView manufacturer = serviceManufacturer.Get(id);
            serviceManufacturer.Remove(manufacturer);
            return RedirectToAction("Manufacturer");
        }
    }
}