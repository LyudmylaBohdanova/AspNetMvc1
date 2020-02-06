using BLL.DTO;
using BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShopAdo.Models
{
    public class ManufacturerView
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
    }
}