using Identity.Api.Core.Dto.UseCaseRequests;
using Identity.Api.Core.Dto.UseCaseResponses;

namespace Identity.Api.Core.Interfaces.UseCases
{
  public interface ILoginUseCase : IUseCaseRequestHandler<LoginRequest, LoginResponse>
  {
  }
}
