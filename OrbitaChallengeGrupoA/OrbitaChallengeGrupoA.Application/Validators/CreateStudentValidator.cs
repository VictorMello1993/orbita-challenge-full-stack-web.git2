using FluentValidation;
using OrbitaChallengeGrupoA.Application.Commands.CreateStudent;
using System.Linq;

namespace OrbitaChallengeGrupoA.Application.Validators
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("O campo nome é obrigatório").NotNull().WithMessage("O campo nome é obrigatório");

            RuleFor(s => s.Email).NotEmpty().WithMessage("O campo e-mail é obrigatório").NotNull().WithMessage("O campo e-mail é obrigatório");
            RuleFor(s => s.Email).EmailAddress().When(s => !string.IsNullOrWhiteSpace(s.Email)).WithMessage("E-mail inválido");

            RuleFor(s => s.AR).NotEmpty().WithMessage("O campo RA é obrigatório").NotNull().WithMessage("O campo RA é obrigatório");
            RuleFor(s => s.AR).Must(ar => ar.Length == 6).When(s => !string.IsNullOrWhiteSpace(s.AR)).WithMessage("RA deve conter exatamente 6 caracteres.");            
            RuleFor(s => s.AR).Must(ar => ar.All(char.IsDigit)).When(s => !string.IsNullOrWhiteSpace(s.AR)).WithMessage("RA deve conter somente números");

            RuleFor(s => s.CPF).NotNull().WithMessage("O campo CPF é obrigatório").NotEmpty().WithMessage("O campo CPF é obrigatório");
            RuleFor(s => s.CPF).Must(cpf => cpf.Length == 12).When(s => !string.IsNullOrWhiteSpace(s.CPF)).WithMessage("CPF deve conter exatamente 12 caracteres.");
            RuleFor(s => s.CPF).Must(cpf => cpf.All(char.IsDigit)).When(s => !string.IsNullOrWhiteSpace(s.CPF)).WithMessage("CPF deve conter somente números");
            RuleFor(s => s.CPF).Must(ValidateCPF).When(s => !string.IsNullOrWhiteSpace(s.CPF)).WithMessage("CPF inválido");
        }

        private bool ValidateCPF(string cpf)
        {
            //PEGAR O PRIMEIRO DÍGITO VERIFICADOR
            //1) Multiplicar os 9 primeiros dígitos, da direita para esquerda, pelos respectivos números crescentes, a partir do 2

            //2) Somar cada resultado obtido no passo 1

            //3)Pegar o resultado do somatório e dividir por 11 para obter o primeiro dígito verificador
                //Se o resto da divisão for menor que 2, o dígito verificador será zero
                //Se o resto da divisão for maior ou igual a 2, o dígito verificador será o 11 menos o resto.

            //PEGAR O SEGUNDO DÍGITO VERIFICADOR
            /*  1)Usar o primeiro dígito verificador e multiplicar por 2, e o restante por outros números crescentes, sempre da direita para esquerda,
                  da mesma forma do que foi feito no cálculo do primeiro dígito verificador.*/

            //2) Repetir os passos conforme o cálculo do primeiro dígito            
        }
    }
}
