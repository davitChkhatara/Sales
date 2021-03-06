using MediatR;
using Sales.Application.Enums;
using Sales.Application.Helpers;
using Sales.Application.Interfaces;
using Sales.Domain.Entities;
using Sales.Domain.Enums;
using Sales.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, IResponse<CreateEmployeeCommandResponse>>
    {
        private readonly ISalesContext _context;

        public CreateEmployeeCommandHandler(ISalesContext context)
        {
            _context = context;
        }
        public async Task<IResponse<CreateEmployeeCommandResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeExists = _context.Employees.FirstOrDefault(e => e.PersonalId.Equals(request.PersonalId) && e.Status == EmployeeStatus.Active) != null;
            if (employeeExists)
            {
                return ResponseHelper.Fail<CreateEmployeeCommandResponse>(ResponseStatusCode.Error, "Employee with given parameters already exists");
            }
            var hasParent = request.ManagerId.HasValue && request.ManagerId > 0;
            var validParent = hasParent ? _context.Employees.FirstOrDefault(e => e.Id == request.ManagerId && e.Status == EmployeeStatus.Active) != null : true;
            if (!validParent)
            {
                return ResponseHelper.Fail<CreateEmployeeCommandResponse>(ResponseStatusCode.Error, "manager id doesn't exist or is not active");
            }

            var manager = _context.Employees.FirstOrDefault(e => e.ManagerId == request.ManagerId && e.Status == EmployeeStatus.Active);
            if (manager != null)
            {
                return ResponseHelper.Fail<CreateEmployeeCommandResponse>(ResponseStatusCode.Error, "manager already has registered sales agent");
            }

            var employee = new Employee
            {
                ManagerId = hasParent ? request.ManagerId : null,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Status = EmployeeStatus.Active,
                PersonalId = request.PersonalId
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return ResponseHelper.Ok(new CreateEmployeeCommandResponse { Id = employee.Id });
        }
    }
}
