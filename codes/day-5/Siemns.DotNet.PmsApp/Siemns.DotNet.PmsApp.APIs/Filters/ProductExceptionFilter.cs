using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Siemns.DotNet.PmsApp.APIs.Filters
{
    //Approach:1
    //public class ProductExceptionFilter : IExceptionFilter
    //{
    //public void OnException(ExceptionContext context)
    //{
    //    var e = context.Exception;
    //    var error = new { Message = e.Message, StatusCode = 500 };
    //    context.Result = new JsonResult(error);
    //    context.ExceptionHandled = true;
    //}
    //}

    //Approach:2
    public class ProductExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var e = context.Exception;
            var error = new { Message = e.Message, StatusCode = 500 };
            context.Result = new JsonResult(error);
            context.ExceptionHandled = true;
        }
    }
}
