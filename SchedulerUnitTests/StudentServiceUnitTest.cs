using BLL.Caching.Base;
using BLL.Converters;
using BLL.Converters.Interface;
using BLL.Services;
using BLL.Services.Interface;
using BLL.ValidationServices;
using BLL.ValidationServices.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace SchedulerUnitTests
{
    public class StudentServiceUnitTest
    {
        [Fact]
        public async void StudentService_Create_Success()
        {
            var createModel = new StudentCreateModel() { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = new Role { Name = "User" } };
            var expected = new StudentViewModel() { Id = createModel.Id, Name = createModel.Name, Role = createModel.Role };

            IStudentConverter studentConverter = new StudentConverter();
            var entity = studentConverter.ConvertToEntity(createModel);

            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(repository => repository.Create(It.Is<Student>(student => student.Name == entity.Name)).Result).Returns(entity);


            IUserValidationService userValidationService = new UserValidationService();

            var mockCacheService = new Mock<ICacheService>();
            mockCacheService.Setup(cacheService => cacheService.Set("key", It.IsAny<Student>()));

            IStudentService service = new StudentService(mockRepository.Object, studentConverter, userValidationService, mockCacheService.Object);
            var actual = await service.Create(createModel);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StudentService_Create_FailedWhenRepositoryReturnsNull()
        {
            var createModel = new StudentCreateModel() { Id = new Guid(), Email = "totalit@gmail.com", Name = "totalit", Password = "123", Role = new Role { Name = "User" } };

            IStudentConverter studentConverter = new StudentConverter();
            Student entity = null;

            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(repository => repository.Create(studentConverter.ConvertToEntity(createModel)).Result).Returns(entity);


            IUserValidationService userValidationService = new UserValidationService();

            var mockCacheService = new Mock<ICacheService>();
            mockCacheService.Setup(cacheService => cacheService.Set("key", It.IsAny<Student>()));

            IStudentService service = new StudentService(mockRepository.Object, studentConverter, userValidationService, mockCacheService.Object);
            Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(createModel));
        }
    }
}
