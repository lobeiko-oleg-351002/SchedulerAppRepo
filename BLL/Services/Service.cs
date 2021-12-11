using BLL.Converters.Interface;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
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

        public virtual async Task<UEntity> Create(YEntity entity)
        { 
            TEntity result = await _repository.Create(_converter.ConvertToEntity(entity));
            return _converter.ConvertToViewModel(result);
        }

        public virtual void Delete(Guid id)
        { 
            _repository.Delete(id);
        }

        public virtual async Task<List<UEntity>> GetAll()
        {
            var query = _repository.GetAll();
            var entities = await query.ToListAsync();
            return entities.Select(_converter.ConvertToViewModel).ToList();
        }

        public virtual async Task<UEntity> Get(Guid id)
        {
            var entity = await _repository.Get(id);
            return _converter.ConvertToViewModel(entity);
        }

        public virtual async Task<UEntity> Update(YEntity entity)
        {
            TEntity result = await _repository.Update(_converter.ConvertToEntity(entity));
            return _converter.ConvertToViewModel(result);
        }

        public string GetKey(string id)
        {
            return typeof(UEntity) + "_" + id;
        }
    }
}
