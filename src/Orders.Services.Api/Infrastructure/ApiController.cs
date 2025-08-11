using Chavp.Domain.Core.Primitives;
using Microsoft.AspNetCore.Mvc;
using Orders.Services.Api.Controllers;

namespace Orders.Services.Api.Infrastructure
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        protected new IActionResult Ok(object value) => base.Ok(value);
        protected IActionResult BadRequest(IReadOnlyCollection<Error> errors)
        {
            var details = new List<string>();
            foreach (var error in errors)
            {
                details.Add($"{error.Code}:{error.Message}");
            }

            var prob1 = base.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: "Bad Request",
                type: "https://datatracker.ietf.org/doc/html/rfc7231#sectio-6.6.1",
                detail: string.Join(", ", details)
                );

            var problemDetails = HttpContext.CreateProblemDetails(
                title: "Bad Request",
                statusCode: StatusCodes.Status400BadRequest,
                errors: errors
                );

            return new ObjectResult(problemDetails);
        }
        protected new IActionResult NotFound() => base.NotFound();

        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger) => _logger = logger;
    }
}
