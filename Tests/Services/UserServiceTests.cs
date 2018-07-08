using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain;
using Core.Repositories;
using FluentAssertions;
using Infrastructure.Services;
using Moq;
using Xunit;

namespace Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("user@gmail.com", "user", "pass", "user");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
        [Fact]

        public async Task when_calling_get_async_and_user_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.GetAsync("user1@gmail.com");

            var user = new User("user1@gmail.com", "user1", "secret", "user", "salt");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task when_calling_get_async_and_user_does_not_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.GetAsync("user@gmail.com");

            userRepositoryMock.Setup(x => x.GetAsync("user@gmail.com"))
                .ReturnsAsync(() => null);

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
    }
}
