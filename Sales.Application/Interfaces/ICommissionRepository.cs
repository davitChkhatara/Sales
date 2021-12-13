using Sales.Application.DataTransferObjects;
using Sales.Application.Employees.Queries.GetCommissions;
using Sales.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Interfaces
{
    public interface ICommissionRepository
    {
        Task<List<EmployeeCommissionsDto>> GetCommissions(GetCommissionsRequest request);
    }
}
