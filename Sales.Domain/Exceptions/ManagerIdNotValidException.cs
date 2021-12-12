using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Exceptions
{
    public class ManagerIdNotValidException : Exception
    {
        public ManagerIdNotValidException() : base("manager id doesn't exist or is not active")
        {

        }
    }
}
