using MediatR;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.SalesOrders.Commands.CreateSalesOrder
{
    public class CreateSalesOrderCommand : IRequest<IResponse<CreateSalesOrderCommandResponse>>
    {
        public long EmployeeId { get; set; }

        public long ProductId { get; set; }

        public decimal Qty { get; set; }
    }

    public class CreateSalesOrderCommandResponse
    {
        public long SalesOrderId { get; set; }
    }
}
