using BLL.Converters.Interface;
using DAL.Repositories.Interface;
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
        private readonly IStudentRepository _studentRepository;
        public SubscriberConverter(IStudentConverter studentConverter, IStudentRepository studentRepository)
        {
            _studentConverter = studentConverter ?? throw new ArgumentNullException(nameof(studentConverter));
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }
        public Subscriber ConvertToEntity(SubscriberCreateModel model)
        {
            Subscriber result = new Subscriber
            {
                Id = model.Id,
                Student = _studentRepository.Get(model.StudentId),
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
