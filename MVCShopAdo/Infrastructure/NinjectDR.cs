using BLL.Modules;
using MVCShopAdo.Models;
using MVCShopAdo.ServiceView;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCShopAdo.Infrastructure
{
    public class NinjectDR : IDependencyResolver
    {
        IKernel kernel;

        public NinjectDR()
        {
            kernel = new StandardKernel(new DIModule());
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
            kernel.Bind<IServiceView<CategoryViewModel>>().To<CategoryViewService>();
            kernel.Bind<IServiceView<GoodViewModel>>().To<GoodViewService>();
            kernel.Bind<IServiceView<ManufacturerViewModel>>().To<ManufacturerViewService>();
        }
    }
}