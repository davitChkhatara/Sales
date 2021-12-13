using MediatR;
using Sales.Application.DataTransferObjects;
using Sales.Application.Helpers;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Employees.Queries.GetCommissions
{
    public class GetCommissionsQueryHandler : IRequestHandler<GetCommissionsQuery, IResponse<List<EmployeeCommissionsDto>>>
    {

        private readonly ICommissionRepository _repo;

        public GetCommissionsQueryHandler(ICommissionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IResponse<List<EmployeeCommissionsDto>>> Handle(GetCommissionsQuery request, CancellationToken cancellationToken)
        {
            var res = await _repo.GetCommissions(new Models.GetCommissionsRequest { EmployeeId = request.EmployeeId ,TransDate = request.TransDate});

            return ResponseHelper.Ok(res);
        }
    }
}
