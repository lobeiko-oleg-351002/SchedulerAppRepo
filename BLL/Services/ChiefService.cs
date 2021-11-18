using BLL.Converters;
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
    public class ChiefService : Service<Chief, ChiefViewModel, ChiefCreateModel>, IChiefService
    {
        public ChiefService(IChiefRepository chiefRepository, IChiefConverter chiefConverter) : base(chiefRepository, chiefConverter)
        {
            
        }

        public List<ChiefViewModel> GetByProfileDescription(string tag)
        {
            var result = new List<ChiefViewModel>();
            ((IChiefRepository)_repository).GetByProfileDescription(tag).Select(_converter.ConvertToViewModel).ToList();
            return result;
        }
    }
}
