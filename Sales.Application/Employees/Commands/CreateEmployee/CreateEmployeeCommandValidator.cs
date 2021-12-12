using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(c => c.PersonalId).NotNull().NotEmpty();
            RuleFor(c => c.FirstName).NotNull().NotEmpty();
            RuleFor(c => c.LastName).NotNull().NotEmpty();
        }
    }
}
