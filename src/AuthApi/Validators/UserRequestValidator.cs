using FluentValidation;
using AuthApi.Models;

namespace AuthApi.Validators;

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(req => req.Email)
            .NotEmpty().WithMessage("The email field is required.")
            .EmailAddress().WithMessage("The email format is invalid.");

        RuleFor(req => req.Username)
            .NotEmpty().WithMessage("The username field is required.")
            .MinimumLength(3).WithMessage("The username must be at least 3 characters long.")
            .MaximumLength(30).WithMessage("The username cannot exceed 30 characters.");

        RuleFor(req => req.Password)
            .NotEmpty().WithMessage("The password field is required.")
            .MinimumLength(8).WithMessage("The password must be at least 8 characters long.")
            .MaximumLength(99).WithMessage("The password cannot exceed 99 characters.")
            .Matches(@"[A-Z]").WithMessage("The password should contain at least 1 uppercase character.")
            .Matches(@"[a-z]").WithMessage("The password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("The password must contain at least one number.")
            .Matches(@"[\W_]").WithMessage("The password must contain at least one special character.");
    }
}
