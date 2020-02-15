using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.Controllers
{
    public class CategoryController : Controller
    {
        private ShopViewServices services;

        private const int itemsCount = 6;

        public CategoryController(ShopViewServices services)
        {
            this.services = services;
        }

        public ActionResult Categories(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(services.serviceCategory.GetAll().Count() / (double)itemsCount);
            return View();
        }

        public ActionResult TableCategories(int id = 1)
        {
            var categories = services.serviceCategory.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(categories);
        }

        public ActionResult EditCategory(int id = 0)
        {
            CategoryViewModel category = services.serviceCategory.Get(id);

            if (id == 0)
                category = new CategoryViewModel();

            return PartialView(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(CategoryViewModel category, string action)
        {
            if (ModelState.IsValid)
            {
                if (action == "save")
                {
                    CategoryViewModel model = services.serviceCategory.Get(category.CategoryId);
                    model.CategoryName = category.CategoryName;
                    services.serviceCategory.CreateOrUpdate(category);
                    TempData["Success"] = $"The category {category.CategoryName} edit success!";
                }
                else if (action == "add")
                {
                    services.serviceCategory.CreateOrUpdate(category);
                    TempData["Success"] = $"The category {category.CategoryName} add success!";
                }
                else if (action == "delete")
                {
                    services.serviceCategory.Remove(category);
                    TempData["Success"] = $"The category {category.CategoryName} delete success!";
                }
                return RedirectToAction("Categories", "Category");
            }

            TempData["Error"] = $"The category {category.CategoryName} has action error!";
            return RedirectToAction("Categories", "Category");
        }
    }
}