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
    public class GoodViewService : IViewService<GoodView>
    {
        IMapper mapper;
        IService<GoodDTO> service;

        public GoodViewService(IService<GoodDTO> service)
        {
            this.service = service;
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<GoodDTO, GoodView>();
                cfg.CreateMap<GoodView, GoodDTO>();
            });
            mapper = config.CreateMapper();
        }

        public GoodView CreateOrUpdate(GoodView data)
        {
            GoodDTO good = mapper.Map<GoodDTO>(data);
            service.CreateOrUpdate(good);
            return mapper.Map<GoodView>(good);
        }

        public GoodView Get(int id)
        {
            GoodDTO good = service.Get(id);
            return mapper.Map<GoodView>(good);
        }

        public IEnumerable<GoodView> GetAll()
        {
            return service.ListAll().Select(x => mapper.Map<GoodView>(x));
        }

        public GoodView Remove(GoodView data)
        {
            GoodDTO good = mapper.Map<GoodDTO>(data);
            service.Remove(good);
            return mapper.Map<GoodView>(good);
        }

        public void Save()
        {
            service.Save();
        }
    }
}