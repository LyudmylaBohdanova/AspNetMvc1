using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.Models
{
    public class CategoryViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a category name")]
        public string CategoryName { get; set; }
    }
}