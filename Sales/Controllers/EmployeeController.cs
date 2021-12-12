using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales.Application.Employees.Commands.CreateEmployee;
using Sales.Application.Employees.Commands.VoidEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public EmployeeController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPut]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand request)
        {
            return Ok(await _mediatr.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> VoidEmployee(VoidEmployeeCommand request)
        {
            return Ok(await _mediatr.Send(request));
        }
    }
}
