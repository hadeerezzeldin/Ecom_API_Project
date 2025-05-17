using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("errors/{statusCode}")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error(int statusCode)
        {
            return new ObjectResult(new ProblemDetails
            {
                Status = statusCode,
                Title = "Error",
                Detail = "An error occurred while processing your request.",

                Instance = HttpContext.Request.Path
            })
            {
                StatusCode = statusCode
            };
        }
    }
}
