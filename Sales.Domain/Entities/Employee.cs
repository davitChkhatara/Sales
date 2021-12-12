using Sales.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Entities
{
    public class Employee
    {
        public long Id { get; set; }

        public string PersonalId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public EmployeeStatus Status { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public long? ManagerId { get; set; }

        public Employee Manager { get; set; }

        public ICollection<Employee> SubEmployees { get; set; }

        public ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
