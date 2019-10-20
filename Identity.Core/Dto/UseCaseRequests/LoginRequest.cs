using Identity.Api.Core.Dto.UseCaseResponses;
using Identity.Api.Core.Interfaces;

namespace Identity.Api.Core.Dto.UseCaseRequests
{
  public class LoginRequest : IUseCaseRequest<LoginResponse>
  {
    public string UserName { get; }
    public string Password { get; }

    public LoginRequest(string userName, string password)
    {
      UserName = userName;
      Password = password;
    }
  }
}
