using BLL.DTO;
using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.Controllers
{
    public class EditController : Controller
    {
        private ShopViewServices services;
        private const int itemsCount = 6;

        public EditController(ShopViewServices services)
        {
            this.services = services;
        }

        #region openmodal

        public ActionResult EditGood(int id = 0)
        {
            GoodView good = services.serviceGood.Get(id);
            ViewBag.Category = services.serviceCategory.GetAll().OrderBy(x => x.CategoryName);
            ViewBag.Manufacturer = services.serviceManufacturer.GetAll().OrderBy(x => x.ManufacturerName);

            if (id == 0)
                good = new GoodView();

            return PartialView(good);
        }
        public ActionResult EditCategory(int id = 0)
        {
            CategoryView category = services.serviceCategory.Get(id);

            if (id == 0)
                category = new CategoryView();

            return PartialView(category);
        }
        public ActionResult EditManufacturer(int id = 0)
        {
            ManufacturerView manufacturer = services.serviceManufacturer.Get(id);

            if (id == 0)
                manufacturer = new ManufacturerView();

            return PartialView(manufacturer);
        }

        #endregion

        #region CreateOrUpdate post

        [HttpPost]
        public ActionResult EditGood (GoodView good, string action)
        {
            if (ModelState.IsValid)
                if (action == "save" || action == "add")
                    services.serviceGood.CreateOrUpdate(good);
                else if (action == "delete")
                    services.serviceGood.Remove(good);

            return RedirectToAction("Goods", "Shop");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(CategoryView category, string action) 
        {
            if (ModelState.IsValid)
                if (action == "save")
                {
                    TempData["message"] = string.Format("{0} has been saved", category.CategoryName);
                    services.serviceCategory.CreateOrUpdate(category);
                    ViewBag.Message = "Category saved";
                    ModelState.Clear();
                }
                else if (action == "delete")
                {
                    TempData["message"] = string.Format("{0} has been deleted", category.CategoryName);
                    services.serviceCategory.Remove(category);
                }
            return RedirectToAction("Categories", "Shop");
        }

        [HttpPost]
        public ActionResult EditManufacturer(ManufacturerView manufacturer, string action)
        {
            if (ModelState.IsValid)
                if (action == "save" || action == "add")
                    services.serviceManufacturer.CreateOrUpdate(manufacturer);
                else if (action == "delete")
                    services.serviceManufacturer.Remove(manufacturer);

            return RedirectToAction("Manufacturer", "Shop");
        }

        #endregion
    }
}