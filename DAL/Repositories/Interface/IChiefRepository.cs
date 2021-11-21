using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IChiefRepository : IRepository<Chief>
    {
        Task<List<Chief>> GetByProfileDescription(string tag);
    }
}
