using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IChiefService : IService<ChiefViewModel>
    {
        public List<ChiefViewModel> GetByProfile(string tag);
    }
}
