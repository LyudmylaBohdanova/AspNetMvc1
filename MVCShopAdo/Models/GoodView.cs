using BLL.DTO;
using BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShopAdo.Models
{
    public class GoodView
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
    }
}