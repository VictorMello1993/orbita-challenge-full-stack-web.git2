using FluentValidation;
using OrbitaChallengeGrupoA.Application.Commands.UpdateUser;

namespace OrbitaChallengeGrupoA.Application.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.Name).NotNull().WithMessage("O campo nome é obrigatório").NotEmpty().WithMessage("O campo nome é obrigatório");

            RuleFor(u => u.Email).NotNull().WithMessage("E-mail é obrigatório").NotEmpty().WithMessage("E-mail é obrigatório");
            RuleFor(u => u.Email).EmailAddress().When(u => !string.IsNullOrWhiteSpace(u.Email)).WithMessage("E-mail inválido");
        }
    }
}
