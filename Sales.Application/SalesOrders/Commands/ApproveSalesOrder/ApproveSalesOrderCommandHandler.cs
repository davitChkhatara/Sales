using MediatR;
using Sales.Application.Helpers;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.SalesOrders.Commands.ApproveSalesOrder
{
    public class ApproveSalesOrderCommandHandler : IRequestHandler<ApproveSalesOrderCommand, IResponse<ApproveSalesOrderCommandResponse>>
    {
        private readonly ISalesContext _context;

        public ApproveSalesOrderCommandHandler(ISalesContext context)
        {
            _context = context;
        }

        public async Task<IResponse<ApproveSalesOrderCommandResponse>> Handle(ApproveSalesOrderCommand request, CancellationToken cancellationToken)
        {
            var salesOrder = _context.SalesOrders.SingleOrDefault(s => s.Id == request.SalesOrderId);
            if (salesOrder == null)
            {
                return ResponseHelper.Fail<ApproveSalesOrderCommandResponse>(Enums.ResponseStatusCode.Error, "sales order was not found");
            }

            if (salesOrder.Status == Domain.Enums.SalesOrderStatus.Approved)
            {
                return ResponseHelper.Fail<ApproveSalesOrderCommandResponse>(Enums.ResponseStatusCode.Error, "sales order is already approved");
            }

            var product = _context.Products.SingleOrDefault(p => p.Id == salesOrder.ProductId);
            if (salesOrder.Qty > product.QtyOnHand)
            {
                return ResponseHelper.Fail<ApproveSalesOrderCommandResponse>(Enums.ResponseStatusCode.Error, "product is not available in inventory");
            }

            salesOrder.Status = Domain.Enums.SalesOrderStatus.Approved;
            salesOrder.ApproveDate = DateTime.Now;
            _context.SalesOrders.Update(salesOrder);

            product.QtyOnHand -= salesOrder.Qty;
            _context.Products.Update(product);

            _context.SaveChanges();

            return ResponseHelper.Ok(new ApproveSalesOrderCommandResponse { });
        }
    }
}
