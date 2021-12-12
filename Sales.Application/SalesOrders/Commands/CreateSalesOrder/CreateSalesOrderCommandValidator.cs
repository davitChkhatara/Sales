using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.SalesOrders.Commands.CreateSalesOrder
{
    public class CreateSalesOrderCommandValidator : AbstractValidator<CreateSalesOrderCommand>
    {
        public CreateSalesOrderCommandValidator()
        {
            RuleFor(c => c.ProductId).NotNull().GreaterThan(0);
            RuleFor(c => c.Qty).NotNull().GreaterThan(0);
            RuleFor(c => c.EmployeeId).NotNull().GreaterThan(0);
        }
    }
}
