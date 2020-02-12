using BLL.DTO;
using BLL.Services;
using DAL.Context;
using DAL.Models;
using DAL.Repositories;
using Ninject.Modules;
using System.Data.Entity;

namespace BLL.Modules
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ShopAdo>();
            Bind<IRepository<Good>>().To<GoodRepository>();
            Bind<IRepository<Category>>().To<CategoryRepository>();
            Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
            Bind<IService<GoodDTO>>().To<GoodService>();
            Bind<IService<CategoryDTO>>().To<CategoryService>();
            Bind<IService<ManufacturerDTO>>().To<ManufacturerService>();
        }
    }
}
