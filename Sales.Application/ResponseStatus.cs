using Sales.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application
{
    public class ResponseStatus
    {
        public ResponseStatusCode Code { get; set; }

        public string Message { get; set; }
    }
}
