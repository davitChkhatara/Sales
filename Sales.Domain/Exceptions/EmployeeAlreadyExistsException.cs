using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Exceptions
{
    public class EmployeeAlreadyExistsException : Exception
    {
        public EmployeeAlreadyExistsException() : base("Employee with given parameters already exists")
        {

        }
    }
}
