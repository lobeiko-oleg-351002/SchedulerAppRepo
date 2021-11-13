using BLL.Converters.Interface;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Service<TEntity, UEntity> : IService<UEntity>
         where TEntity : Entity
         where UEntity : ViewModel
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IConverter<TEntity, UEntity> Converter;
        public Service(IRepository<TEntity> repository, IConverter<TEntity, UEntity> converter)
        {
            Repository = repository;
            Converter = converter;
        }

        public virtual void Create(UEntity entity)
        {
            try
            { 
              Repository.Create(Converter.ConvertToEntity(entity));
            }
            catch
            {
                throw;
            }
        }

        public virtual void Delete(Guid id)
        {
            try
            { 
               Repository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public virtual List<UEntity> GetAll()
        {
            var result = new List<UEntity>();
            try
            {
                Repository.GetAll().ForEach(item => result.Add(Converter.ConvertToViewModel(item)));
                return result;
            }
            catch
            {
                throw;
            }
        }

        public virtual UEntity Get(Guid id)
        {
            try
            {
                return Converter.ConvertToViewModel(Repository.Get(id));
            }
            catch
            {
                throw;
            }
        }

        public virtual void Update(UEntity entity)
        {
            try
            {
                Repository.Update(Converter.ConvertToEntity(entity));
            }
            catch
            {
                throw;
            }
        }
    }
}
