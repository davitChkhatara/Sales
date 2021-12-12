using MediatR;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Employees.Commands.VoidEmployee
{
    public class VoidEmployeeCommand : IRequest<IResponse<VoidEmployeeCommandResponse>>
    {
        public long Id { get; set; }
    }

    public class VoidEmployeeCommandResponse
    {

    }
}
