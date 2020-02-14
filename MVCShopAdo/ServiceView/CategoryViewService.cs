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
    public class CategoryViewService : IServiceView<CategoryViewModel>
    {
        IService<CategoryDTO> service;
        IMapper mapper;

        public CategoryViewService(IService<CategoryDTO> service)
        {
            this.service = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, CategoryViewModel>();
            });
            mapper = config.CreateMapper();
        }
        public CategoryViewModel CreateOrUpdate(CategoryViewModel data)
        {
            CategoryDTO category = mapper.Map<CategoryDTO>(data);
            service.CreateOrUpdate(category);
            return mapper.Map<CategoryViewModel>(category);
        }

        public CategoryViewModel Get(int id)
        {
            CategoryDTO category = service.Get(id);
            return mapper.Map<CategoryViewModel>(category);
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            return service.GetAll().Select(x => mapper.Map<CategoryViewModel>(x));
        }

        public CategoryViewModel Remove(CategoryViewModel data)
        {
            CategoryDTO category = mapper.Map<CategoryDTO>(data);
            service.Remove(category);
            return mapper.Map<CategoryViewModel>(category);
        }

        public void Save()
        {
            service.Save();
        }
    }
}