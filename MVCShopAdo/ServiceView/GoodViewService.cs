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
    public class GoodViewService : IServiceView<GoodView>
    {
        IService<GoodDTO> service;
        IMapper mapper;

        public GoodViewService(IService<GoodDTO> service)
        {
            this.service = service;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GoodView, GoodDTO>();
                cfg.CreateMap<GoodDTO, GoodView>();
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
            return service.GetAll().Select(x => mapper.Map<GoodView>(x));
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