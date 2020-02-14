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
    public class ManufacturerViewService : IServiceView<ManufacturerViewModel>
    {
        IService<ManufacturerDTO> service;
        IMapper mapper;

        public ManufacturerViewService(IService<ManufacturerDTO> service)
        {
            this.service = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManufacturerViewModel, ManufacturerDTO>();
                cfg.CreateMap<ManufacturerDTO, ManufacturerViewModel>();
            });
            mapper = config.CreateMapper();
        }
        public ManufacturerViewModel CreateOrUpdate(ManufacturerViewModel data)
        {
            ManufacturerDTO manufacturer = mapper.Map<ManufacturerDTO>(data);
            service.CreateOrUpdate(manufacturer);
            return mapper.Map<ManufacturerViewModel>(manufacturer);
        }

        public ManufacturerViewModel Get(int id)
        {
            ManufacturerDTO manufacturer = service.Get(id);
            return mapper.Map<ManufacturerViewModel>(manufacturer);
        }

        public IEnumerable<ManufacturerViewModel> GetAll()
        {
            return service.GetAll().Select(x => mapper.Map<ManufacturerViewModel>(x));
        }

        public ManufacturerViewModel Remove(ManufacturerViewModel data)
        {
            ManufacturerDTO manufacturer = mapper.Map<ManufacturerDTO>(data);
            service.Remove(manufacturer);
            return mapper.Map<ManufacturerViewModel>(manufacturer);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}