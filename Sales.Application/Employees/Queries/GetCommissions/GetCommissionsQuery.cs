using MediatR;
using Sales.Application.DataTransferObjects;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Employees.Queries.GetCommissions
{
    public class GetCommissionsQuery : IRequest<IResponse<List<EmployeeCommissionsDto>>>
    {
        public long EmployeeId { get; set; }

        public DateTime TransDate { get; set; }
    }
}
