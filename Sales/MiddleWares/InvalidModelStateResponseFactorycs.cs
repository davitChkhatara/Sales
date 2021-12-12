using Microsoft.AspNetCore.Mvc;
using Sales.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.MiddleWares
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            string messages = string.Join("; ", context.ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            var response = ResponseHelper.Fail(Application.Enums.ResponseStatusCode.Error, messages);

            return new BadRequestObjectResult(response);
        }
    }
}
