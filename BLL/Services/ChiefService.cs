using BLL.Converters;
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
    public class ChiefService : Service<Chief, ChiefViewModel>, IChiefService
    {
        public ChiefService(IChiefRepository chiefRepository, IChiefConverter chiefConverter) : base(chiefRepository, chiefConverter)
        {
            
        }

        public List<ChiefViewModel> GetByProfile(string tag)
        {
            var result = new List<ChiefViewModel>();
            ((IChiefRepository)Repository).GetByProfile(tag).ForEach(item => result.Add(Converter.ConvertToViewModel(item)));
            return result;
        }
    }
}
