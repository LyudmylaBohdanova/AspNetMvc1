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
        // GET: Home
        /*
        public ActionResult Index()
        {
            return View();
        }
        */
        public ActionResult Goods()
        {
            ViewBag.Goods = serviceGood.ListAll();
            return View();
        }
        public ActionResult Categories()
        {
            ViewBag.Categories = serviceCategory.ListAll();
            return View();
        }
        public ActionResult Manufacturer()
        {
            ViewBag.Manufacturer = serviceManufacturer.ListAll();
            return View();
        }
    }
}