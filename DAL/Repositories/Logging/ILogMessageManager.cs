using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Logging
{
    public interface ILogMessageManager<TEntity>
        where TEntity : Entity
    {
        public void LogEntityCreation(TEntity entity);

        public void LogEntityUpdate(TEntity entity);

        public void LogSuccess();

        public void LogGetAll();

        public void LogFailure(string message);

        public void LogDelete(Guid id);

        public void LogGet(Guid id);

        public void LogCustomMessage(string message);
    }
}
