using BLL.Converters.Interface;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Service<TEntity, UEntity, YEntity> : IService<UEntity, YEntity>
         where TEntity : Entity
         where UEntity : ViewModel
         where YEntity : CreateModel
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IConverter<YEntity, UEntity, TEntity> _converter;
        public Service(IRepository<TEntity> repository, IConverter<YEntity, UEntity, TEntity> converter)
        {
            _repository = repository;
            _converter = converter;
        }

        public virtual UEntity Create(YEntity entity)
        { 
            TEntity result = _repository.Create(_converter.ConvertToEntity(entity));
            return _converter.ConvertToViewModel(result);
        }

        public virtual void Delete(Guid id)
        { 
            _repository.Delete(id);
        }

        public virtual List<UEntity> GetAll()
        {
            var result = new List<UEntity>();
            _repository.GetAll().ForEach(item => result.Add(_converter.ConvertToViewModel(item)));
            return result;
        }

        public virtual UEntity Get(Guid id)
        {
            return _converter.ConvertToViewModel(_repository.Get(id));
        }

        public virtual UEntity Update(YEntity entity)
        {
            TEntity result = _repository.Update(_converter.ConvertToEntity(entity));
            return _converter.ConvertToViewModel(result);
        }
    }
}
