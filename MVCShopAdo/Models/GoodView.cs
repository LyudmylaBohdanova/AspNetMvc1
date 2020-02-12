using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.Models
{
    public class GoodView
    {
        [HiddenInput(DisplayValue = false)]
        public int GoodId { get; set; }

        [Required(ErrorMessage = "Please enter a good name")]
        public string GoodName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? ManufacturerId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? CategoryId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a correct price")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a correct count")]
        public decimal GoodCount { get; set; }

        public string CategoryName { get; set; }

        public string ManufacturerName { get; set; }
    }
}