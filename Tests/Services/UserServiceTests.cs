using AutoMapper;
using Core.Domain;
using Core.Repositories;
using Infrastructure.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encryptedMock = new Mock<IEncrypter>();
            encryptedMock.Setup(x => x.GetSalt()).Returns("salt");
            encryptedMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("hash");
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, encryptedMock.Object, mapperMock.Object);
            await userService.RegisterAsync(Guid.NewGuid(), "user@gmail.com", "user", "pass", "user");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
        [Fact]

        public async Task when_calling_get_async_and_user_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encryptedMock = new Mock<IEncrypter>();
            encryptedMock.Setup(x => x.GetSalt()).Returns("salt");
            encryptedMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("hash");
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, encryptedMock.Object, mapperMock.Object);
            await userService.GetAsync("user1@gmail.com");

            var user = new User(Guid.NewGuid(), "user1@gmail.com", "user1", "secret", "user", "salt");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task when_calling_get_async_and_user_does_not_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encryptedMock = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, encryptedMock.Object, mapperMock.Object);
            await userService.GetAsync("user@gmail.com");

            userRepositoryMock.Setup(x => x.GetAsync("user@gmail.com"))
                .ReturnsAsync(() => null);

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
    }
}
