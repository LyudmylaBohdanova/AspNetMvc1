﻿using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.MVC.Controllers
{
    public class ManufacturerController : Controller
    {
        private ShopViewServices services;

        private const int itemsCount = 6;

        public ManufacturerController(ShopViewServices services)
        {
            this.services = services;
        }

        public ActionResult Manufacturer(int id = 1)
        {
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            ViewBag.UserRole = 0;
            foreach (var i in roles)
                if (i == "admin")
                    ViewBag.UserRole = 1;

            ViewBag.PageCount = (int)Math.Ceiling(services.serviceManufacturer.GetAll().Count() / (double)itemsCount);
            return View();
        }

        public ActionResult TableManufacturers(int id = 1)
        {
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            ViewBag.UserRole = 0;
            foreach (var i in roles)
                if (i == "admin")
                    ViewBag.UserRole = 1;

            var manufacturers = services.serviceManufacturer.GetAll().Skip((id - 1) * itemsCount).Take(itemsCount);
            return PartialView(manufacturers);
        }
        
        [Authorize]
        public ActionResult EditManufacturer(int id = 0)
        {
            ManufacturerViewModel manufacturer = services.serviceManufacturer.Get(id);

            if (id == 0)
                manufacturer = new ManufacturerViewModel();

            return PartialView(manufacturer);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditManufacturer(ManufacturerViewModel manufacturer, string action)
        {
            if (ModelState.IsValid)
            {
                if (action == "save")
                {
                    services.serviceManufacturer.CreateOrUpdate(manufacturer);
                    TempData["Success"] = $"The category {manufacturer.ManufacturerName} edit success!";
                }
                else if(action == "add")
                {
                    services.serviceManufacturer.CreateOrUpdate(manufacturer);
                    TempData["Success"] = $"The category {manufacturer.ManufacturerName} add success!";
                }
                else if (action == "delete")
                {
                    services.serviceManufacturer.Remove(manufacturer);
                    TempData["Success"] = $"The category {manufacturer.ManufacturerName} delete success!";
                }
            }
            
            TempData["Error"] = $"The category {manufacturer.ManufacturerName} has action error!";
            return RedirectToAction("Manufacturer", "Manufacturer");
        }
    }
}