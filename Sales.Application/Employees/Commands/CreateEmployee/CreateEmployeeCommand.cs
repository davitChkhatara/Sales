using MediatR;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<IResponse<CreateEmployeeCommandResponse>>
    {
        public long? ManagerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalId { get; set; }
    }

    public class CreateEmployeeCommandResponse
    {
        public long Id { get; set; }
    }
}
