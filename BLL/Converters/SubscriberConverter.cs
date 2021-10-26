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
    public class SubscriberConverter : ISubscriberConverter
    {
        private readonly IStudentConverter StudentConverter;
        public SubscriberConverter(IStudentConverter studentConverter)
        {
            StudentConverter = studentConverter ?? throw new ArgumentNullException(nameof(studentConverter));
        }
        public Subscriber ConvertToEntity(SubscriberViewModel model)
        {
            Subscriber result = new Subscriber
            {
                Id = model.Id,
                IsConfirmed = model.IsConfirmed,
                Student = StudentConverter.ConvertToEntity(model.StudentViewModel),
            };
            return result;
        }

        public SubscriberViewModel ConvertToViewModel(Subscriber entity)
        {
            SubscriberViewModel result = new SubscriberViewModel
            {
                Id = entity.Id,
                IsConfirmed = entity.IsConfirmed,
                StudentViewModel = StudentConverter.ConvertToViewModel(entity.Student),
            };
            return result;
        }
    }
}
