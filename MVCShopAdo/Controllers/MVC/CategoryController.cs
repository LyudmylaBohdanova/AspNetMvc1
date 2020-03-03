using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.MVC.Controllers
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
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            ViewBag.UserRole = 0;
            foreach (var i in roles)
                if (i == "admin")
                    ViewBag.UserRole = 1;

            ViewBag.PageCount = (int)Math.Ceiling(services.serviceCategory.GetAll().Count() / (double)itemsCount);
            return View();
        }

        public ActionResult TableCategories(int id = 1)
        {
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            ViewBag.UserRole = 0;
            foreach (var i in roles)
                if (i == "admin")
                    ViewBag.UserRole = 1;

            var categories = services.serviceCategory.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(categories);
        }

        [Authorize]
        public ActionResult EditCategory(int id = 0)
        {
            CategoryViewModel category = services.serviceCategory.Get(id);

            if (id == 0)
                category = new CategoryViewModel();

            return PartialView(category);
        }

        [Authorize]
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