using FluentValidation;

namespace Olivia.DTOs;

public sealed record RegisterTenant
{

    public string Name { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

};

public class RegisterTenantValidator : AbstractValidator<RegisterTenant>
{

    public RegisterTenantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotNull()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotNull()
            .MinimumLength(8);
    }

}

public sealed record AuthTenant
{
    public string Email { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;
};