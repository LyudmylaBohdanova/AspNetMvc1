using AutoMapper;
using BLL.DTO;
using BLL.Modules;
using BLL.Services;
using MVCShopAdo.Models;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace MVCShopAdo.ServicesView
{
    public class CategoryViewService : IViewService<CategoryView>
    {
        IMapper mapper;
        IService<CategoryDTO> serviceCategory;

        public CategoryViewService(IService<CategoryDTO> serviceCategory)
        {
            this.serviceCategory = serviceCategory;
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<CategoryDTO, CategoryView>();
                cfg.CreateMap<CategoryView, CategoryDTO>();
            });
            mapper = config.CreateMapper();
        }

        public CategoryView CreateOrUpdate(CategoryView data)
        {
            CategoryDTO category = mapper.Map<CategoryDTO>(data);
            serviceCategory.CreateOrUpdate(category);
            return mapper.Map<CategoryView>(category);
        }

        public CategoryView Get(int id)
        {
            var cat = serviceCategory.Get(id);
            return mapper.Map<CategoryView>(cat);
        }

        public IEnumerable<CategoryView> GetAll()
        {
            return serviceCategory.ListAll().Select(x => mapper.Map<CategoryView>(x));
        }

        public CategoryView Remove(CategoryView data)
        {
            CategoryDTO category = mapper.Map<CategoryDTO>(data);
            serviceCategory.Remove(category);
            return mapper.Map<CategoryView>(category);
        }

        public void Save()
        {
            serviceCategory.Save();
        }
    }
}