using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.SalesOrders.Commands.ApproveSalesOrder
{
    public class ApproveSalesOrderCommandValidator : AbstractValidator<ApproveSalesOrderCommand>
    {
        public ApproveSalesOrderCommandValidator()
        {
            RuleFor(c => c.SalesOrderId).NotNull().GreaterThan(0);
        }
    }
}
