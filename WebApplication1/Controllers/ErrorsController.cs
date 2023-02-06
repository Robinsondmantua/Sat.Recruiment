using System.Net;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruiment.Api.Model;
using Sat.Recruiment.Application.Common.Exceptions;

namespace Sat.Recruiment.Api.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public abstract class ErrorsController : ControllerBase
    {
        [Route("error")]
        public CustomErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = (int)HttpStatusCode.InternalServerError;

            if (exception is DuplicateDataException)
            {
                code = (int)HttpStatusCode.Conflict;
            }
            if (exception is ValidationException)
            {
                code = (int)HttpStatusCode.BadRequest;
            }

            Response.StatusCode = code;

            return new CustomErrorResponse(exception.Source);
        }
    }
}
