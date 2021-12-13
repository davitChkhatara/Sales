using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sales.Application.DataTransferObjects;
using Sales.Application.Interfaces;
using Sales.Application.Models;
using Sales.Application.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure
{
    public class CommissionRepository : ICommissionRepository
    {
        private readonly DatabaseOptions _databaseOptions;

        public CommissionRepository(IOptions<DatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions.Value;
        }

        public async Task<List<EmployeeCommissionsDto>> GetCommissions(GetCommissionsRequest request)
        {
            using (var context = new SalesContext())
            {
                var query = await context.Set<EmployeeCommissionsDto>().FromSqlRaw("EXECUTE dbo.calculate_commision {0},{1}", request.EmployeeId, request.TransDate).ToListAsync();

                return query;
            }
        }
    }
}
