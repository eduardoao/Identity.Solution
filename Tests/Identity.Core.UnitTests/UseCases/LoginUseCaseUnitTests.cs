using System.Threading.Tasks;
using Moq;
using Identity.Api.Core.Domain.Entities;
using Identity.Api.Core.Dto;
using Identity.Api.Core.Dto.UseCaseRequests;
using Identity.Api.Core.Dto.UseCaseResponses;
using Identity.Api.Core.Interfaces;
using Identity.Api.Core.Interfaces.Gateways.Repositories;
using Identity.Api.Core.Interfaces.Services;
using Identity.Api.Core.UseCases;
using Xunit;

namespace Identity.Api.Core.UnitTests.UseCases
{
    public class LoginUseCaseUnitTests
    {
        [Fact]
        public async void Can_Login()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new User("", "", "", "")));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new Token("", "", 0)));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("userName", "password"), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }

        [Fact]
        public async void Cant_Login_When_Missing_Username()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new User("", "", "", "")));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new Token("", "", 0)));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password"), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }


        [Fact]
        public async void Cant_Login_When_Unknown_Account()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult<User>(null));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new Token("", "", 0)));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password"), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }

        [Fact]
        public async void Cant_Login_When_Password_Validation_Fails()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult<User>(null));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new Token("", "", 0)));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password"), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }
    }
}
