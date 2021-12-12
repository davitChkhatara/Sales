using MediatR;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.SalesOrders.Commands.ApproveSalesOrder
{
    public class ApproveSalesOrderCommand : IRequest<IResponse<ApproveSalesOrderCommandResponse>>
    {
        public long SalesOrderId { get; set; }
    }

    public class ApproveSalesOrderCommandResponse
    {

    }
}
