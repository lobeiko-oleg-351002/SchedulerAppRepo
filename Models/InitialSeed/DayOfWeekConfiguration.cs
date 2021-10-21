using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels.InitialSeed
{
    public class DayOfWeekConfiguration : IEntityTypeConfiguration<DayOfWeek>
    {
        public void Configure(EntityTypeBuilder<DayOfWeek> builder)
        {
            builder.HasData
            (
                new DayOfWeek
                {
                    Id = Guid.NewGuid(),
                    Name = "Monday",
                },
                new DayOfWeek
                {
                    Id = Guid.NewGuid(),
                    Name = "Tuesday",
                },
                new DayOfWeek
                {
                    Id = Guid.NewGuid(),
                    Name = "Wednesday",
                },
                new DayOfWeek
                {
                    Id = Guid.NewGuid(),
                    Name = "Thursday",
                },
                new DayOfWeek
                {
                    Id = Guid.NewGuid(),
                    Name = "Friday",
                },
                new DayOfWeek
                {
                    Id = Guid.NewGuid(),
                    Name = "Saturday",
                },
                new DayOfWeek
                {
                    Id = Guid.NewGuid(),
                    Name = "Sunday",
                }
            );
        }
    }
}
