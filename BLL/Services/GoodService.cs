using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GoodService : IService<GoodDTO>
    {
        IRepository<Good> repository;
        IMapper mapper;
        public GoodService(IRepository<Good> repository)
        {
            this.repository = repository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Good, GoodDTO>()
                .ForMember(x => x.CategoryName, s => s.MapFrom(x => x.Category.CategoryName))
                .ForMember(x => x.ManufacturerName, s => s.MapFrom(x => x.Manufacturer.ManufacturerName));
                cfg.CreateMap<GoodDTO, Good>();
            });
            mapper = config.CreateMapper();
        }

        public GoodDTO CreateOrUpdate(GoodDTO dto)
        {
            Good good = mapper.Map<Good>(dto);
            repository.CreateOrUpdate(good);
            return mapper.Map<GoodDTO>(good);
        }

        public GoodDTO Get(int id)
        {
            var good = repository.Get(id);
            return mapper.Map<GoodDTO>(good);
        }

        public IEnumerable<GoodDTO> GetAll()
        {
            return repository.GetAll().Select(x => mapper.Map<GoodDTO>(x));
        }

        public GoodDTO Remove(GoodDTO dto)
        {
            Good good = mapper.Map<Good>(dto);
            repository.Remove(good);
            return dto;
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
