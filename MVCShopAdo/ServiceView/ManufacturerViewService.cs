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
    public class ManufacturerViewService : IServiceView<ManufacturerView>
    {
        IService<ManufacturerDTO> service;
        IMapper mapper;

        public ManufacturerViewService(IService<ManufacturerDTO> service)
        {
            this.service = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManufacturerView, ManufacturerDTO>();
                cfg.CreateMap<ManufacturerDTO, ManufacturerView>();
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
            return service.GetAll().Select(x => mapper.Map<ManufacturerView>(x));
        }

        public ManufacturerView Remove(ManufacturerView data)
        {
            ManufacturerDTO manufacturer = mapper.Map<ManufacturerDTO>(data);
            service.Remove(manufacturer);
            return mapper.Map<ManufacturerView>(manufacturer);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}