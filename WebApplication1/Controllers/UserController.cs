using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruiment.Api.Dto.Request;

namespace Sat.Recruiment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] NewUserDto command)
        {
            return Ok();
        }
    }
}
