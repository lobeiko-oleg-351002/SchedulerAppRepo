using BLL.Exceptions;
using BLL.ValidationServices;
using BLL.ValidationServices.Interface;
using SchedulerModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchedulerUnitTests
{
    public class UserValidationServiceUnitTests
    {
        private readonly IUserValidationService _userValidationService = new UserValidationService();

        public static IEnumerable<object[]> StudentEntitiesEmptyOrNull
        {
            get
            {
                return new[]
                {
                    new object[] { null },

                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = null } },

                    new object[] { new Student { Id = new Guid(), Email = "a", Name = "totalit", Password = "123", Role = new Role() } },
                    new object[] { new Student { Id = new Guid(), Email = string.Empty, Name = "totalit", Password = "123", Role = new Role() } },
                    new object[] { new Student { Id = new Guid(), Email = "123", Name = "totalit", Password = "123", Role = new Role() } },

                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = string.Empty, Password = "123", Role = new Role() } },

                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = string.Empty, Role = new Role() } },
                 };
            }
        }

        public static IEnumerable<object[]> StudentEntitiesValid
        {
            get
            {
                return new[]
                {
                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = "tot", Password = "123", Role = new Role() } },

                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "asdfasdf", Role = new Role() } },
                 };
            }
        }

        [Theory, MemberData(nameof(StudentEntitiesEmptyOrNull))]
        public void UserValidationService_ValidateNewUser_ThrowsExceptionWhenModelIsNull(Student entity)
        {
            Assert.Throws<UserValidationException>(() => _userValidationService.ValidateNewUser(entity));
        }

        [Theory]
        [InlineData("", "1234")]
        [InlineData("1234", "")]
        [InlineData("", "")]
        [InlineData("12", "1234")]
        [InlineData("12", "12")]
        [InlineData("123", "12")]
        public void UserValidationService_ValidateNameAndPassword_Failed(string name, string password)
        {
            Assert.Throws<UserValidationException>(() => _userValidationService.ValidateNameAndPassword(name, password));
        }

        [Theory, MemberData(nameof(StudentEntitiesValid))]
        public void UserValidationService_ValidateNewUser_Success(Student entity)
        {
            var exception = Record.Exception(() => _userValidationService.ValidateNewUser(entity));
            Assert.Null(exception);
        }


    }
}
