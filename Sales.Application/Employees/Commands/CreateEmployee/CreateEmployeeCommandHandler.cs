using MediatR;
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
            var employeeExists = _context.Employees.FirstOrDefault(e => e.PersonalId.Equals(request.PersonalId)) != null;
            if (employeeExists)
            {
                throw new EmployeeAlreadyExistsException();
            }
            var hasParent = request.ManagerId.HasValue && request.ManagerId > 0;
            var validParent = hasParent ? _context.Employees.FirstOrDefault(e => e.Id == request.ManagerId && e.Status == EmployeeStatus.Active) != null : true;
            if (!validParent)
            {
                throw new ManagerIdNotValidException();
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
