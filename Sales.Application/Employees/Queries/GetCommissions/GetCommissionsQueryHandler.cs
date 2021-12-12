using MediatR;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Employees.Queries.GetCommissions
{
    public class GetCommissionsQueryHandler : IRequestHandler<GetCommissionsQuery, IResponse<int>>
    {
        public async Task<IResponse<int>> Handle(GetCommissionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
