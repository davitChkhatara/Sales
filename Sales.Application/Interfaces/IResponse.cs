using Sales.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Interfaces
{
    public interface IResponse<TResponse>
    {
        TResponse Data { get; set; }

        public ResponseStatus Status { get; set; }
    }
}
