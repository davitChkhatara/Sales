using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.SalesOrders.Commands.ApproveSalesOrder;
using Sales.Application.SalesOrders.Commands.CreateSalesOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public SalesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPut]
        public async Task<IActionResult> CreateSalesOrder(CreateSalesOrderCommand request)
        {
            return Ok(await _mediatr.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> ApproveSalesOrder(ApproveSalesOrderCommand request)
        {
            return Ok(await _mediatr.Send(request));
        }
    }
}
