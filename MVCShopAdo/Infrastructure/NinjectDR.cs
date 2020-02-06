using BLL.DTO;
using BLL.Modules;
using BLL.Services;
using DAL.Context;
using DAL.Repositories;
using MVCShopAdo.Models;
using MVCShopAdo.ServicesView;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace MVCShopAdo.Infrastructure
{
    public class NinjectDR : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDR()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<DbContext>().To<ShopAdoEntities>();
            kernel.Bind<IRepository<Good>>().To<GoodRepository>();
            kernel.Bind<IRepository<Category>>().To<CategoryRepository>();
            kernel.Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
            kernel.Bind<IService<GoodDTO>>().To<GoodService>();
            kernel.Bind<IService<CategoryDTO>>().To<CategoryService>();
            kernel.Bind<IService<ManufacturerDTO>>().To<ManufacturerService>();
            kernel.Bind<IViewService<GoodView>>().To<GoodViewService>();
            kernel.Bind<IViewService<CategoryView>>().To<CategoryViewService>();
            kernel.Bind<IViewService<ManufacturerView>>().To<ManufacturerViewService>();
        }

    }
}