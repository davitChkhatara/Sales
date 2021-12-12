using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sales.Application
{
    public class AppResponse<TResponse> : IResponse<TResponse>
    {
        public TResponse Data { get; set; }

        public ResponseStatus Status { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
