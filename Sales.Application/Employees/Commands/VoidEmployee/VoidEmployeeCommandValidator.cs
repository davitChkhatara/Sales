using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Employees.Commands.VoidEmployee
{
    public class VoidEmployeeCommandValidator : AbstractValidator<VoidEmployeeCommand>
    {
        public VoidEmployeeCommandValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
        }
    }
}
