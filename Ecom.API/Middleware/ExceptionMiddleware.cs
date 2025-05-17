using System.Runtime.CompilerServices;
using System.Text.Json;
using Amazon.CodePipeline.Model;
using Azure.Core;
using Ecom.API.Helper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;


namespace Ecom.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache memoryCashe;
        private readonly IWebHostEnvironment environment;
        private readonly TimeSpan _realLimitWindow = TimeSpan.FromSeconds(30);

        public ExceptionMiddleware(RequestDelegate next, IMemoryCache memoryCashe, IWebHostEnvironment _environment)
        {
            _next = next;
            environment = _environment;
            this.memoryCashe = memoryCashe;
        }
        public async Task InvokeAsync(HttpContext context , IWebHostEnvironment _environment)
        {
            ApplySecurity(context);
            try
            {
                if(IsRequestAllowed(context) == false)
                {
                    context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    context.Response.ContentType = "application/json";
                    var json = JsonSerializer.Serialize(new Helper.ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Too many requests. Please try again later."
                    });
                    await context.Response.WriteAsync(json);
                    return;
                }
               await  _next(context);
            }
            catch (Exception ex)
            {
                //HandleExceptionAsync(context, ex);
                context.Response.StatusCode =StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var errorDetails = new Helper.ErrorDetails();
             
                if (_environment.IsDevelopment())
                {

                    errorDetails.StatusCode = context.Response.StatusCode;
                        errorDetails.Message = "Internal Server Error. Please try again later.";
                        errorDetails.StackTrace = ex.StackTrace;
                    

                } else
                {

                    errorDetails.StatusCode = context.Response.StatusCode;
                        errorDetails.Message = "Internal Server Error. Please try again later.";
                        errorDetails.StackTrace = null;
                    
                }

                    var json = JsonSerializer.Serialize(new Helper.ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = ex.Message,
                        StackTrace = ex.StackTrace

                    });
                await context.Response.WriteAsync(json);
            }
        }

        private bool IsRequestAllowed(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress;
            var cashKey = $"Rate{ip}";
            var dateNow = DateTime.Now;
           
          ( var timesTamp , var count) = memoryCashe.GetOrCreate(cashKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _realLimitWindow;
                return (timesTamp:dateNow,count: 0);
            });

            if( dateNow- timesTamp < _realLimitWindow)
            {
                if (count > 8)
                {
                    memoryCashe.Set(cashKey, (timesTamp: dateNow, count: count += 1), _realLimitWindow);

                } else
                {
                    memoryCashe.Set(cashKey, (timesTamp: dateNow, count: count), _realLimitWindow);
                }
            }
            return true;


        }



        private void ApplySecurity(HttpContext context)
        {
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
            context.Response.Headers["X-Frame-Options"] = "DENY";
        }


    }
}
