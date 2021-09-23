using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Students.Commands;
using FluentValidation;

namespace Api.Validators
{
    public class DeleteStudentValidator:  AbstractValidator<DeleteStudentCommand.Contract>
    {
        public DeleteStudentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().NotNull().WithMessage("Informe o id do usuário");
        }
    }
}
