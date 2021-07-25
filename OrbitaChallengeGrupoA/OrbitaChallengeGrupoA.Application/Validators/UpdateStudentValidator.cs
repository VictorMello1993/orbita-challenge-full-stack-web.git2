using FluentValidation;
using OrbitaChallengeGrupoA.Application.Commands.UpdateStudent;

namespace OrbitaChallengeGrupoA.Application.Validators
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("O campo nome é obrigatório").NotNull().WithMessage("O campo nome é obrigatório");
            RuleFor(s => s.Email).NotEmpty().WithMessage("O campo e-mail é obrigatório").NotNull().WithMessage("O campo e-mail é obrigatório");
            RuleFor(s => s.Email).EmailAddress().When(s => !string.IsNullOrWhiteSpace(s.Email)).WithMessage("E-mail inválido");
        }
    }
}
