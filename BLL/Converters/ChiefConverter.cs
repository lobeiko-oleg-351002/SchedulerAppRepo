using BLL.Converters.Interface;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public class ChiefConverter : IChiefConverter
    {
        private readonly IStudentConverter _studentConverter;
        public ChiefConverter(IStudentConverter studentConverter)
        {
            _studentConverter = studentConverter ?? throw new ArgumentNullException(nameof(studentConverter));
        }
        public Chief ConvertToEntity(ChiefCreateModel model)
        {
            Chief user = new Chief(_studentConverter.ConvertToEntity(model));
            user.Profile = model.Profile;
            return user;
        }

        public ChiefViewModel ConvertToViewModel(Chief entity)
        {
            ChiefViewModel user = new ChiefViewModel(_studentConverter.ConvertToViewModel(entity));
            user.Profile = entity.Profile;
            return user;
        }


    }
}
