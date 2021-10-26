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
            Repository.Create(Converter.ConvertToEntity(entity));
        }

        public virtual void Delete(Guid id)
        {
            Repository.Delete(id);
        }

        public virtual List<UEntity> GetAll()
        {
            var result = new List<UEntity>();
            Repository.GetAll().ForEach(item => result.Add(Converter.ConvertToViewModel(item)));
            return result;
        }

        public virtual UEntity Get(Guid id)
        {
            return Converter.ConvertToViewModel(Repository.Get(id));
        }

        public virtual void Update(UEntity entity)
        {
            Repository.Update(Converter.ConvertToEntity(entity));
        }
    }
}
