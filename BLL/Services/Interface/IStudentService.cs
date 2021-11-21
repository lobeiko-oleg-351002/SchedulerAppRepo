using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IStudentService : IService<StudentViewModel, StudentCreateModel>
    {
        public Task<StudentViewModel> GetByNameAndPassword(string name, string password);
    }
}
