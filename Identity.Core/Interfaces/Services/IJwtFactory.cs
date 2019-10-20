using System.Threading.Tasks;
using Identity.Api.Core.Dto;

namespace Identity.Api.Core.Interfaces.Services
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id, string userName);
    }
}
