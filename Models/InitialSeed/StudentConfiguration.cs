using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels.InitialSeed
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData
            (
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "John",
                    Password = "shepard2072",
                    Email = "normandy@gmail.com",
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Raynor",
                    Password = "raiders44",
                    Email = "eugene@gmail.com",
                }
            );
        }
    }
}
