using System.Threading.Tasks;
using Identity.Core.Domain.Entities;
using Identity.Core.Dto.GatewayResponses.Repositories;

namespace Identity.Core.Interfaces.Gateways.Repositories
{
    public interface IUserRepository  : IRepository<User>
    {
        Task<CreateUserResponse> Create(string firstName, string lastName, string email, string userName, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
    }
}
