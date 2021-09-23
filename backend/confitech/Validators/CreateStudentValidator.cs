using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Students.Commands;
using Domain.Students.Enumerations;
using FluentValidation;

namespace Api.Validators
{
    public class CreateStudentValidator: AbstractValidator<CreateStudentCommand.Contract>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Informe o nome do aluno")
                .Length(3, 100).WithMessage("informe um nome válido");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Informe o email do aluno")
                .EmailAddress().WithMessage("informe um email válido");

            RuleFor(x => x.BornDate).Must(Utils.Utils.BornDateValidator)
                .WithMessage("Sua data de nascimento não pode ser maior ou igual a hoje");

            RuleFor(x => x.Scholarity).Must(Utils.Utils.ScholarityValidator)
                .WithMessage("Informe uma escolaridade valida");
        }

    }
}
