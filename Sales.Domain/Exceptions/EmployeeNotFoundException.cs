using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() : base("Employee with given key was not found")
        {

        }
    }
}
