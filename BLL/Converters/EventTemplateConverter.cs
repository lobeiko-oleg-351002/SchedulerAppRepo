using BLL.Converters.Interface;
using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public class EventTemplateConverter : IEventTemplateConverter
    {
        public EventTemplate ConvertToEntity(EventTemplateViewModel model)
        {
            EventTemplate result = new EventTemplate
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
            };
            return result;
        }

        public EventTemplateViewModel ConvertToViewModel(EventTemplate entity)
        {
            EventTemplateViewModel result = new EventTemplateViewModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
            };
            return result;
        }
    }
}
