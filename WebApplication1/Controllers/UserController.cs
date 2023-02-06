using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruiment.Api.Dto.Request;
using Sat.Recruiment.Application.Features.Users.Commands.Request;

namespace Sat.Recruiment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateUser([FromBody] NewUserRequest command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction(nameof(CreateUser), result);
        }
    }
}