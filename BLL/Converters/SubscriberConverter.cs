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
    public class SubscriberConverter : ISubscriberConverter
    {
        private readonly IStudentConverter _studentConverter;
        public SubscriberConverter(IStudentConverter studentConverter)
        {
            _studentConverter = studentConverter ?? throw new ArgumentNullException(nameof(studentConverter));
        }
        public Subscriber ConvertToEntity(SubscriberCreateModel model)
        {
            Subscriber result = new Subscriber
            {
                Id = model.Id,
               // Student = _studentConverter.ConvertToEntity(model.StudentViewModel),
            };
            return result;
        }

        public SubscriberViewModel ConvertToViewModel(Subscriber entity)
        {
            SubscriberViewModel result = new SubscriberViewModel
            {
                Id = entity.Id,
                IsConfirmed = entity.IsConfirmed,
                StudentViewModel = _studentConverter.ConvertToViewModel(entity.Student),
            };
            return result;
        }
    }
}
