using System.Threading.Tasks;
using Identity.Api.Core.Domain.Entities;
using Identity.Api.Core.Dto.GatewayResponses.Repositories;

namespace Identity.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository
    {
        Task<CreateUserResponse> Create(User user, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
    }
}
