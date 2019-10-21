using System.Net;
using Identity.Core.Dto.UseCaseResponses;
using Identity.Core.Interfaces;
using Identity.Serialization;

namespace Identity.Presenters
{
    public sealed class ExchangeRefreshTokenPresenter : IOutputPort<ExchangeRefreshTokenResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ExchangeRefreshTokenPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ExchangeRefreshTokenResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new Models.Response.ExchangeRefreshTokenResponse(response.AccessToken, response.RefreshToken)) : JsonSerializer.SerializeObject(response.Message);
        }
    }
}
