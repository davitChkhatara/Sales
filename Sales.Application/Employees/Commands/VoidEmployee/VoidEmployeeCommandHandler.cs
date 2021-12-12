using MediatR;
using Sales.Application.Enums;
using Sales.Application.Helpers;
using Sales.Application.Interfaces;
using Sales.Domain.Enums;
using Sales.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Employees.Commands.VoidEmployee
{
    public class VoidEmployeeCommandHandler : IRequestHandler<VoidEmployeeCommand, IResponse<VoidEmployeeCommandResponse>>
    {
        private readonly ISalesContext _context;

        public VoidEmployeeCommandHandler(ISalesContext context)
        {
            _context = context;
        }

        public async Task<IResponse<VoidEmployeeCommandResponse>> Handle(VoidEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == request.Id && e.Status == EmployeeStatus.Active);
            if (employee == null)
            {
                return ResponseHelper.Fail<VoidEmployeeCommandResponse>(ResponseStatusCode.Error, "Employee with given key was not found");
            }

            employee.LastUpdateDate = DateTime.Now;
            employee.Status = EmployeeStatus.Void;

            // get parent employee id of this employee
            var managerId = employee.ManagerId.HasValue && employee.ManagerId > 0 ? employee.Manager.ManagerId : null;
            // get all child employees and  update with new parent
            var subEmployees = _context.Employees.Where(e => e.ManagerId == employee.Id).ToList();
            if (subEmployees != null && subEmployees.Count > 0) 
            { 
                foreach (var empl in subEmployees)
                {
                    empl.ManagerId = managerId;
                    empl.LastUpdateDate = DateTime.Now;
                    _context.Employees.Update(empl);
                }
            }

            _context.Employees.Update(employee);
            _context.SaveChanges();

            return ResponseHelper.Ok(new VoidEmployeeCommandResponse { });
        }
    }
}
