using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Identity.Api.Core.Dto.UseCaseRequests;
using Identity.Api.Core.Interfaces.UseCases;
using Identity.Api.Presenters;

namespace Identity.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly RegisterUserPresenter _registerUserPresenter;

        public AccountsController(IRegisterUserUseCase registerUserUseCase, RegisterUserPresenter registerUserPresenter)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _registerUserUseCase.Handle(new RegisterUserRequest(request.FirstName,request.LastName,request.Email, request.UserName,request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }
    }
}
