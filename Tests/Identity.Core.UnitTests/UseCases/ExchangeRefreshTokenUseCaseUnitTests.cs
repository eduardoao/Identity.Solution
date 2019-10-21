using System.Security.Claims;
using Identity.Core.Domain.Entities;
using Identity.Core.Dto;
using Identity.Core.Dto.UseCaseRequests;
using Identity.Core.Dto.UseCaseResponses;
using Identity.Core.Interfaces;
using Identity.Core.Interfaces.Gateways.Repositories;
using Identity.Core.Interfaces.Services;
using Identity.Core.Specifications;
using Identity.Core.UseCases;
using Moq;
using Xunit;

namespace Identity.Core.UnitTests.UseCases
{
    public class ExchangeRefreshTokenUseCaseUnitTests
    {
        [Fact]
        public async void Handle_GivenInvalidToken_ShouldFail()
        {
            // arrange
            var mockJwtTokenValidator = new Mock<IJwtTokenValidator>();
            mockJwtTokenValidator.Setup(validator => validator.GetPrincipalFromToken(It.IsAny<string>(), It.IsAny<string>())).Returns((ClaimsPrincipal)null);

            var mockOutputPort = new Mock<IOutputPort<ExchangeRefreshTokenResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<ExchangeRefreshTokenResponse>()));

            var useCase = new ExchangeRefreshTokenUseCase(mockJwtTokenValidator.Object, null, null, null);

            // act
            var response = await useCase.Handle(new ExchangeRefreshTokenRequest("", "", ""), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }

        [Fact]
        public async void Handle_GivenValidToken_ShouldSucceed()
        {
            // arrange
            var mockJwtTokenValidator = new Mock<IJwtTokenValidator>();
            mockJwtTokenValidator.Setup(validator => validator.GetPrincipalFromToken(It.IsAny<string>(), It.IsAny<string>())).Returns(new ClaimsPrincipal(new[]
            {
                new ClaimsIdentity(new []{ new Claim("id","111-222-333")})
            }));

            const string refreshToken = "1234";
            var user = new User("", "", "", "");
            user.AddRefreshToken(refreshToken, 0, "");

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetSingleBySpec(It.IsAny<UserSpecification>())).ReturnsAsync(user);

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory.Setup(factory => factory.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new AccessToken("", 0));

            var mockTokenFactory = new Mock<ITokenFactory>();
            mockTokenFactory.Setup(factory => factory.GenerateToken(32)).Returns("");

            var mockOutputPort = new Mock<IOutputPort<ExchangeRefreshTokenResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<ExchangeRefreshTokenResponse>()));

            var useCase = new ExchangeRefreshTokenUseCase(mockJwtTokenValidator.Object, mockUserRepository.Object, mockJwtFactory.Object, mockTokenFactory.Object);

            // act
            var response = await useCase.Handle(new ExchangeRefreshTokenRequest("", refreshToken, ""), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }
    }
}
