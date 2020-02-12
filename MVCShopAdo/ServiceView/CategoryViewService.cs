using AutoMapper;
using BLL.DTO;
using BLL.Services;
using MVCShopAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShopAdo.ServiceView
{
    public class CategoryViewService : IServiceView<CategoryView>
    {
        IService<CategoryDTO> service;
        IMapper mapper;

        public CategoryViewService(IService<CategoryDTO> service)
        {
            this.service = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryView, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, CategoryView>();
            });
            mapper = config.CreateMapper();
        }
        public CategoryView CreateOrUpdate(CategoryView data)
        {
            CategoryDTO category = mapper.Map<CategoryDTO>(data);
            service.CreateOrUpdate(category);
            return mapper.Map<CategoryView>(category);
        }

        public CategoryView Get(int id)
        {
            CategoryDTO category = service.Get(id);
            return mapper.Map<CategoryView>(category);
        }

        public IEnumerable<CategoryView> GetAll()
        {
            return service.GetAll().Select(x => mapper.Map<CategoryView>(x));
        }

        public CategoryView Remove(CategoryView data)
        {
            CategoryDTO category = mapper.Map<CategoryDTO>(data);
            service.Remove(category);
            return mapper.Map<CategoryView>(category);
        }

        public void Save()
        {
            service.Save();
        }
    }
}