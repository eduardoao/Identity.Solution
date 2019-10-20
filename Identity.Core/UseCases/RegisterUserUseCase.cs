using System.Linq;
using System.Threading.Tasks;
using Identity.Api.Core.Domain.Entities;
using Identity.Api.Core.Dto.UseCaseRequests;
using Identity.Api.Core.Dto.UseCaseResponses;
using Identity.Api.Core.Interfaces;
using Identity.Api.Core.Interfaces.Gateways.Repositories;
using Identity.Api.Core.Interfaces.UseCases;

namespace Identity.Api.Core.UseCases
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(new User(message.FirstName, message.LastName,message.Email, message.UserName), message.Password);
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}
