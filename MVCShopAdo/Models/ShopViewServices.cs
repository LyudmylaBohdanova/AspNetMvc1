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
        public IServiceView<GoodView> serviceGood;
        public IServiceView<ManufacturerView> serviceManufacturer;
        public IServiceView<CategoryView> serviceCategory;

        public ShopViewServices(IServiceView<GoodView> serviceGood, IServiceView<CategoryView> serviceCategory,
            IServiceView<ManufacturerView> serviceManufacturer)
        {
            this.serviceGood = serviceGood;
            this.serviceCategory = serviceCategory;
            this.serviceManufacturer = serviceManufacturer;
        }
    }
}