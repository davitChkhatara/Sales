using MediatR;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Employees.Queries.GetCommissions
{
    public class GetCommissionsQuery : IRequest<IResponse<int>>
    {
        public long EmployeeId { get; set; }
    }
}
