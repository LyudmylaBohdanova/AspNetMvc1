using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCShopAdo.Models
{
    public class ManufacturerViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ManufacturerId { get; set; }

        [Required(ErrorMessage = "Please enter a manufacturer name")]
        public string ManufacturerName { get; set; }
    }
}