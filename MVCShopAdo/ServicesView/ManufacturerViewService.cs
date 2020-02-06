using AutoMapper;
using BLL.DTO;
using BLL.Modules;
using BLL.Services;
using MVCShopAdo.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShopAdo.ServicesView
{
    public class ManufacturerViewService : IViewService<ManufacturerView>
    {
        IMapper mapper;
        IService<ManufacturerDTO> service;

        public ManufacturerViewService(IService<ManufacturerDTO> service)
        {
            this.service = service;
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<ManufacturerDTO, ManufacturerView>();
                cfg.CreateMap<ManufacturerView, ManufacturerDTO>();
            });
            mapper = config.CreateMapper();
        }

        public ManufacturerView CreateOrUpdate(ManufacturerView data)
        {
            ManufacturerDTO manufacturer = mapper.Map<ManufacturerDTO>(data);
            service.CreateOrUpdate(manufacturer);
            return mapper.Map<ManufacturerView>(manufacturer);
        }

        public ManufacturerView Get(int id)
        {
            ManufacturerDTO manufacturer = service.Get(id);
            return mapper.Map<ManufacturerView>(manufacturer);
        }

        public IEnumerable<ManufacturerView> GetAll()
        {
            return service.ListAll().Select(x => mapper.Map<ManufacturerView>(x));
        }

        public ManufacturerView Remove(ManufacturerView data)
        {
            ManufacturerDTO manufacturer = mapper.Map<ManufacturerDTO>(data);
            service.Remove(manufacturer);
            return mapper.Map<ManufacturerView>(manufacturer);
        }

        public void Save()
        {
            service.Save();
        }
    }
}