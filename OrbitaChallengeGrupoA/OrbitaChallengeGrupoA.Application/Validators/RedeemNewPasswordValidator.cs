using FluentValidation;
using OrbitaChallengeGrupoA.Application.Commands;
using System.Text.RegularExpressions;

namespace OrbitaChallengeGrupoA.Application.Validators
{
    public class RedeemNewPasswordValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public RedeemNewPasswordValidator()
        {
            RuleFor(u => u.Email).NotNull().WithMessage("E-mail é obrigatório").NotEmpty().WithMessage("E-mail é obrigatório");
            RuleFor(u => u.Email).EmailAddress().When(u => !string.IsNullOrWhiteSpace(u.Email)).WithMessage("E-mail inválido");

            RuleFor(u => u).Custom((user, context) =>
            {
                if (user.NewPassword != user.ConfirmNewPassword)
                {
                    context.AddFailure("As senhas não coincidem umas às outras.");
                }

                if (!ValidatePassword(user.NewPassword) || !ValidatePassword(user.ConfirmNewPassword))
                {
                    context.AddFailure("Senha incorreta. Ela deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caracter especial.");
                }
            });
        }

        private bool ValidatePassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);            
        }
    }
}
