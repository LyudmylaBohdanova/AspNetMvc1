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
    public class CategoryService : IService<CategoryDTO>
    {
        IRepository<Category> repository;
        IMapper mapper;
        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
            });
            mapper = config.CreateMapper();
        }


        public CategoryDTO CreateOrUpdate(CategoryDTO dto)
        {
            if(dto.CategoryId == 0)
            {
                Category cat = mapper.Map<Category>(dto);
                repository.CreateOrUpdate(cat);
                return mapper.Map<CategoryDTO>(cat);
            }
            else
            {
                Category category = repository.Get(dto.CategoryId);
                category.CategoryName = dto.CategoryName;
                repository.CreateOrUpdate(category);
                return mapper.Map<CategoryDTO>(category);
            }
        }

        public CategoryDTO Get(int id)
        {
            var cat = repository.Get(id);
            return mapper.Map<CategoryDTO>(cat);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return repository.GetAll().Select(x => mapper.Map<CategoryDTO>(x));
        }

        public CategoryDTO Remove(CategoryDTO dto)
        {
            Category cat = mapper.Map<Category>(dto);
            repository.Remove(cat);
            return dto;
        }

        public void Save()
        {
            repository.Save();
        }

    }
}
