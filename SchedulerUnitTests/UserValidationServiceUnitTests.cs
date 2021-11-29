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

        public static IEnumerable<object[]> StudentEntitiesEmptyOrIncorrectEmail
        {
            get
            {
                return new[]
                {
                    new object[] { new Student { Id = new Guid(), Email = "a", Name = "totalit", Password = "123", Role = new Role() } },
                    new object[] { new Student { Id = new Guid(), Email = string.Empty, Name = "totalit", Password = "123", Role = new Role() } },
                    new object[] { new Student { Id = new Guid(), Email = "123", Name = "totalit", Password = "123", Role = new Role() } },
                 };
            }
        }

        public static IEnumerable<object[]> StudentEntitiesRoleIsNull
        {
            get
            {
                return new[]
                {
                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = null } },
                };
            }
        }

        public static IEnumerable<object[]> StudentEntitiesNameIsEmptyOrIncorrect
        {
            get
            {
                return new[]
                {
                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = string.Empty, Password = "123", Role = new Role() } },
                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = "a", Password = "123", Role = new Role() } },
                };
            }
        }

        public static IEnumerable<object[]> StudentEntitiesPasswordIsEmptyOrIncorrect
        {
            get
            {
                return new[]
                {
                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = string.Empty, Role = new Role() } },
                    new object[] { new Student { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "12", Role = new Role() } },
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

        [Fact]
        public void UserValidationService_ValidateNewUser_UserIsNullException()
        {
            Assert.Throws<UserValidationExceptionUserIsNull>(() => _userValidationService.ValidateNewUser(null));
        }

        [Theory, MemberData(nameof(StudentEntitiesEmptyOrIncorrectEmail))]
        public void UserValidationService_ValidateNewUser_IncorrectEmailException(Student entity)
        {
            Assert.Throws<UserValidationExceptionInvalidEmail>(() => _userValidationService.ValidateNewUser(entity));
        }

        [Theory, MemberData(nameof(StudentEntitiesNameIsEmptyOrIncorrect))]
        public void UserValidationService_ValidateNewUser_InvalidNameException(Student entity)
        {
            Assert.Throws<UserValidationExceptionInvalidName>(() => _userValidationService.ValidateNewUser(entity));
        }

        [Theory, MemberData(nameof(StudentEntitiesPasswordIsEmptyOrIncorrect))]
        public void UserValidationService_ValidateNewUser_InvalidPasswordException(Student entity)
        {
            Assert.Throws<UserValidationExceptionInvalidPassword>(() => _userValidationService.ValidateNewUser(entity));
        }

        [Theory, MemberData(nameof(StudentEntitiesRoleIsNull))]
        public void UserValidationService_ValidateNewUser_RoleIsNullException(Student entity)
        {
            Assert.Throws<UserValidationExceptionRoleIsNull>(() => _userValidationService.ValidateNewUser(entity));
        }

        [Theory]
        [InlineData("", "1234")]
        [InlineData("12", "1234")]
        public void UserValidationService_ValidateNameAndPassword_FailedOnInvalidName(string name, string password)
        {
            Assert.Throws<UserValidationExceptionInvalidName>(() => _userValidationService.ValidateNameAndPassword(name, password));
        }

        [Theory]
        [InlineData("123", "12")]
        [InlineData("1234", "")]
        public void UserValidationService_ValidateNameAndPassword_FailedOnInvalidPassword(string name, string password)
        {
            Assert.Throws<UserValidationExceptionInvalidPassword>(() => _userValidationService.ValidateNameAndPassword(name, password));
        }

        [Theory, MemberData(nameof(StudentEntitiesValid))]
        public void UserValidationService_ValidateNewUser_Success(Student entity)
        {
            var exception = Record.Exception(() => _userValidationService.ValidateNewUser(entity));
            Assert.Null(exception);
        }


    }
}
