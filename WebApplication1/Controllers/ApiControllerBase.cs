using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sat.Recruiment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;

        protected ApiControllerBase()
        {

        }

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
