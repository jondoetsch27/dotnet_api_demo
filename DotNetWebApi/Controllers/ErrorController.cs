using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_demo.Controllers;

[ApiController]
public class ErrorController(ILogger<ErrorController> _logger) : ControllerBase
{
    [Route("/error")]
    public IActionResult HandleError()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;

        if (exception != null)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");
        }

        return Problem();
    }
}