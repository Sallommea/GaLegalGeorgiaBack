using FluentValidation;
using GaLegalGeorgia.Application.Features.Admin.Queries;

namespace GaLegalGeorgia.Application.Features.Admin.Auth
{
    internal sealed class AuthValidator : AbstractValidator<Authorize>
    {
        public AuthValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is invalid");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(8)
                .WithMessage("Invalid password");
        }
    }
}
