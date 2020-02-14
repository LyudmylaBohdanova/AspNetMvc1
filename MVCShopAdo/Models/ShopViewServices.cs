using BLL.Services;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCShopAdo.ServiceView;

namespace MVCShopAdo.Models
{
    public class ShopViewServices
    {
        public IServiceView<GoodViewModel> serviceGood;
        public IServiceView<ManufacturerViewModel> serviceManufacturer;
        public IServiceView<CategoryViewModel> serviceCategory;

        public ShopViewServices(IServiceView<GoodViewModel> serviceGood, IServiceView<CategoryViewModel> serviceCategory,
            IServiceView<ManufacturerViewModel> serviceManufacturer)
        {
            this.serviceGood = serviceGood;
            this.serviceCategory = serviceCategory;
            this.serviceManufacturer = serviceManufacturer;
        }
    }
}