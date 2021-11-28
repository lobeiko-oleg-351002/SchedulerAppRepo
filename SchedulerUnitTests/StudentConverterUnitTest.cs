using BLL.Converters;
using BLL.Converters.Interface;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace SchedulerUnitTests
{
    public class StudentConverterUnitTest
    {
        private readonly IStudentConverter _studentConverter = new StudentConverter();

        public static IEnumerable<object[]> StudentEntities
        {
            get
            {
                return new[]
                {
                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = new Role() { Name = "User" } } },
                    new object[] { new Student { Id = new Guid(), Email = string.Empty, Name = "totalit", Password = "123", Role = new Role() { Name = "User" } } }
                 };
            }
        }

        public static IEnumerable<object[]> StudentCreateModels
        {
            get
            {
                return new[]
                {
                    new object[] { new StudentCreateModel { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = new Role() { Name = "User" } } },
                    new object[] { new StudentCreateModel { Id = new Guid(), Email = string.Empty, Name = "totalit", Password = "123", Role = new Role() { Name = "User" } } }
                 };
            }
        }

        [Theory, MemberData(nameof(StudentEntities))]
        public void StudentConverter_ConvertToViewModel(Student entity)
        {
            var expected = new StudentViewModel { Id = entity.Id, Name = entity.Name, Role = entity.Role };
            var actual = _studentConverter.ConvertToViewModel(entity);

            Assert.Equal(expected.Role, actual.Role);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
        }

        [Theory, MemberData(nameof(StudentCreateModels))]
        public void StudentConverter_ConvertToEntity(StudentCreateModel createModel)
        {
            var expected = new Student { Id = createModel.Id, Name = createModel.Name, Role = createModel.Role, Email = createModel.Email, Password = createModel.Password };
            var actual = _studentConverter.ConvertToEntity(createModel);

            Assert.Equal(expected.Role, actual.Role);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Password, actual.Password);
            Assert.Equal(expected.Email, actual.Email);
        }

        [Fact]
        public void Test()
        {
            Assert.True(true);
        }
    }
}
