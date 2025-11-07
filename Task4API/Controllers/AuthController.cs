using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using Task4API.CQRS.CommandDB.Command;
using Task4API.CQRS.CommandDB.DTO;
using Task4API.CQRS.CommandDB.Command;
using MyMediator.Interfaces;

namespace Task4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginData data)
        {
            var command = new LoginCommand() { Data = data };
            var result = await mediator.SendAsync(command);
            if (result != null)
                return Ok(result);

            return Forbid();
        }
    }
}
