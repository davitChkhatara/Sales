using MediatR;
using Sales.Application.Enums;
using Sales.Application.Helpers;
using Sales.Application.Interfaces;
using Sales.Domain.Entities;
using Sales.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.SalesOrders.Commands.CreateSalesOrder
{
    public class CreateSalesOrderCommandHandler : IRequestHandler<CreateSalesOrderCommand,IResponse<CreateSalesOrderCommandResponse>>
    {
        private readonly ISalesContext _context;

        public CreateSalesOrderCommandHandler(ISalesContext context)
        {
            _context = context;
        }

        public async Task<IResponse<CreateSalesOrderCommandResponse>> Handle(CreateSalesOrderCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == request.ProductId);
            
            if (product == null)
            {
                ResponseHelper.Fail(ResponseStatusCode.Error, "product was not found");
            }

            var employee = _context.Employees.SingleOrDefault(e => e.Id == request.EmployeeId && e.Status == EmployeeStatus.Active);
            if (employee == null)
            {
                ResponseHelper.Fail(ResponseStatusCode.Error, "employee was not found");
            }

            if(request.Qty > product.QtyOnHand)
            {
                ResponseHelper.Fail(ResponseStatusCode.Error, "product is not available in inventory");
            }

            var amount = request.Qty * product.Price;

            var salesOrder = new SalesOrder
            {
                EmployeeId = request.EmployeeId,
                Qty = request.Qty,
                Amount = amount,
                Price = product.Price,
                Status = SalesOrderStatus.Created,
                CreateDate = DateTime.Now
            };

            _context.SalesOrders.Add(salesOrder);
            _context.SaveChanges();

            return ResponseHelper.Ok(new CreateSalesOrderCommandResponse { Id = salesOrder.Id });
        }
    }
}
