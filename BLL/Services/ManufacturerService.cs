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
    public class ManufacturerService : IService<ManufacturerDTO>
    {
        IRepository<Manufacturer> repository;
        IMapper mapper;
        public ManufacturerService(IRepository<Manufacturer> repository)
        {
            this.repository = repository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Manufacturer, ManufacturerDTO>();
                cfg.CreateMap<ManufacturerDTO, Manufacturer>();
            });
            mapper = config.CreateMapper();
        }
        public ManufacturerDTO CreateOrUpdate(ManufacturerDTO dto)
        {
            if(dto.ManufacturerId == 0)
            {
                Manufacturer man = mapper.Map<Manufacturer>(dto);
                repository.CreateOrUpdate(man);
                return mapper.Map<ManufacturerDTO>(man);
            }
            else
            {
                Manufacturer manufacturer = repository.Get(dto.ManufacturerId);
                manufacturer.ManufacturerName = dto.ManufacturerName;
                repository.CreateOrUpdate(manufacturer);
                return mapper.Map<ManufacturerDTO>(manufacturer);
            }
        }

        public ManufacturerDTO Get(int id)
        {
            var man = repository.Get(id);
            return mapper.Map<ManufacturerDTO>(man);
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            return repository.GetAll().Select(x => mapper.Map<ManufacturerDTO>(x));
        }

        public ManufacturerDTO Remove(ManufacturerDTO dto)
        {
            Manufacturer man = mapper.Map<Manufacturer>(dto);
            repository.Remove(man);
            return dto;
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
