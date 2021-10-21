using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels.InitialSeed
{
    public class ChiefConfiguration : IEntityTypeConfiguration<Chief>
    {
        public void Configure(EntityTypeBuilder<Chief> builder)
        {
            builder.HasData
            (
                new Chief
                {
                    Id = Guid.NewGuid(),
                    Name = "Totalit",
                    Password = "vitebsk2021",
                    Email = "totalit280@gmail.com",
                    Profile = "Discussion Club",       
                },
                new Chief
                {
                    Id = Guid.NewGuid(),
                    Name = "Lars Ulrich",
                    Password = "drumdrum",
                    Email = "mlarsm@gmail.com",
                    Profile = "Drum Club"
                }
            );
        }
    }
}
