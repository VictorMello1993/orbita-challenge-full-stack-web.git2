using FluentValidation;
using OrbitaChallengeGrupoA.Application.Commands.CreateStudent;
using System.Collections.Generic;
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
            RuleFor(s => s.CPF).Must(cpf => cpf.Length == 11).When(s => !string.IsNullOrWhiteSpace(s.CPF)).WithMessage("CPF deve conter exatamente 11 caracteres.");
            RuleFor(s => s.CPF).Must(cpf => cpf.All(char.IsDigit)).When(s => !string.IsNullOrWhiteSpace(s.CPF)).WithMessage("CPF deve conter somente números");
            RuleFor(s => s.CPF).Must(ValidateCPF).When(s => !string.IsNullOrWhiteSpace(s.CPF) && s.CPF.Length == 11).WithMessage("CPF inválido");
        }

        private bool ValidateCPF(string cpf)
        {
            var cpfToCompare = cpf.Substring(0, cpf.Length - 2);
            var times = 0;

            while (times < 2)
            {
                var temp = MapTo(cpfToCompare.ToArray());                
                var tempSum = temp.Sum();
                
                temp.ToList().Clear();

                var remainder = tempSum % 11;
                var verifyDigit = remainder < 2 ? 0 : 11 - remainder;
                
                cpfToCompare = string.Concat(cpfToCompare, verifyDigit.ToString());

                times++;
            }

            return cpf == cpfToCompare;
        }

        private int[] MapTo(char[] array)
        {
            var temp = new List<int>();

            for (int i = array.Length - 1, j = 2; i >= 0; i--, j++)
            {
                var result = int.Parse(array[i].ToString()) * j;
                temp.Add(result);
            }

            return temp.ToArray();
        }
    }
}
