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
    public class GoodViewService : IServiceView<GoodViewModel>
    {
        IService<GoodDTO> service;
        IMapper mapper;

        public GoodViewService(IService<GoodDTO> service)
        {
            this.service = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GoodViewModel, GoodDTO>();
                cfg.CreateMap<GoodDTO, GoodViewModel>();
            });
            mapper = config.CreateMapper();
        }
        public GoodViewModel CreateOrUpdate(GoodViewModel data)
        {
            GoodDTO good = mapper.Map<GoodDTO>(data);
            service.CreateOrUpdate(good);
            return mapper.Map<GoodViewModel>(good);
        }

        public GoodViewModel Get(int id)
        {
            GoodDTO good = service.Get(id);
            return mapper.Map<GoodViewModel>(good);
        }

        public IEnumerable<GoodViewModel> GetAll()
        {
            return service.GetAll().Select(x => mapper.Map<GoodViewModel>(x));
        }

        public GoodViewModel Remove(GoodViewModel data)
        {
            GoodDTO good = mapper.Map<GoodDTO>(data);
            service.Remove(good);
            return mapper.Map<GoodViewModel>(good);
        }

        public void Save()
        {
            service.Save();
        }
    }
}