using FluentValidation;
using Identity.Api.Models.Request;

namespace Identity.Api.Models.Validation
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.UserName).Length(5, 255);
            RuleFor(x => x.Password).Length(6, 15);
        }
    }
}
