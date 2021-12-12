using Sales.Application.Enums;
using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Application.Helpers
{
    public static class ResponseHelper
    {
        public static IResponse<TResponse> Ok<TResponse>(TResponse data, string message = null)
            where TResponse : class
        {
            var result = new AppResponse<TResponse>()
            {
                Data = data,
                Status = new ResponseStatus
                {
                    Code = ResponseStatusCode.Success,
                    Message = message
                }
            };

            return result;
        }

        public static IResponse<EmptyResponse> Ok(string message = null)
        {
            return Ok(default(EmptyResponse), message);
        }

        public static IResponse<TResponse> Fail<TResponse>(ResponseStatusCode statusCode = ResponseStatusCode.Error, string message = null, TResponse data = null)
            where TResponse : class
        {
            var result = new AppResponse<TResponse>()
            {
                Data = data,
                Status = new ResponseStatus
                {
                    Code = statusCode,
                    Message = message
                }
            };

            return result;
        }

        public static IResponse<EmptyResponse> Fail(ResponseStatusCode statusCode = ResponseStatusCode.Error, string message = null)
        {
            return Fail<EmptyResponse>(statusCode, message);
        }
    }
}
