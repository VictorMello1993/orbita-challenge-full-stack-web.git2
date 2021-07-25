using FluentValidation;
using OrbitaChallengeGrupoA.Application.Commands.CreateUser;
using System.Text.RegularExpressions;

namespace OrbitaChallengeGrupoA.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Name).NotNull().WithMessage("O campo nome é obrigatório").NotEmpty().WithMessage("O campo nome é obrigatório");

            RuleFor(u => u.Email).NotNull().WithMessage("E-mail é obrigatório").NotEmpty().WithMessage("E-mail é obrigatório");
            RuleFor(u => u.Email).EmailAddress().When(u => !string.IsNullOrWhiteSpace(u.Email)).WithMessage("E-mail inválido");

            RuleFor(u => u.Password).Must(ValidPassword).WithMessage(@"Senha incorreta. Ela deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma 
                                                                       minúscula, e um caracter especial.");            
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
