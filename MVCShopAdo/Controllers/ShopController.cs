using BLL.DTO;
using BLL.Modules;
using BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.Controllers
{
    public class ShopController : Controller
    {
        IKernel kernel;
        IService<GoodDTO> serviceGood => kernel.Get<IService<GoodDTO>>();
        IService<CategoryDTO> serviceCategory => kernel.Get<IService<CategoryDTO>>();
        IService<ManufacturerDTO> serviceManufacturer => kernel.Get<IService<ManufacturerDTO>>();
        public ShopController()
        {
            kernel = new StandardKernel(new DIModule());
        }
        /*
        
        */
        public ActionResult Goods(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(serviceGood.ListAll().Count() / 6.0);
            ViewBag.Goods = serviceGood.ListAll().Skip((id - 1) * 6).Take(6);
            return View();
        }
        public ActionResult Categories(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(serviceCategory.ListAll().Count() / 6.0);
            ViewBag.Categories = serviceCategory.ListAll().Skip((id - 1) * 6).Take(6);
            return View();
        }
        public ActionResult Manufacturer(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(serviceManufacturer.ListAll().Count() / 6.0);
            ViewBag.Manufacturer = serviceManufacturer.ListAll().Skip((id - 1) * 6).Take(6);
            return View();
        }
        public ActionResult DeleteGoods(int id)
        {
            serviceGood.Remove(serviceGood.Get(id));
            return RedirectToAction("Goods");
        }
        public ActionResult DeleteCategories(int id)
        {
            CategoryDTO category = serviceCategory.Get(id);
            serviceCategory.Remove(category);
            return RedirectToAction("Categories");
        }
        public ActionResult DeleteManufacturer(int id)
        {
            ManufacturerDTO manufacturer = serviceManufacturer.Get(id);
            serviceManufacturer.Remove(manufacturer);
            return RedirectToAction("Manufacturer");
        }
    }
}