using BLL.Converters.Interface;
using SchedulerModels;
using SchedulerViewModels;


namespace BLL.Converters
{
    public class DayOfWeekConverter : IDayOfWeekConverter
    {
        public DayOfWeek ConvertToEntity(DayOfWeekViewModel model)
        {
            DayOfWeek day = new DayOfWeek
            {
                Id = model.Id,
                Name = model.Name,
            };
            return day;
        }

        public DayOfWeekViewModel ConvertToViewModel(DayOfWeek entity)
        {
            DayOfWeekViewModel day = new DayOfWeekViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return day;
        }
    }
}
