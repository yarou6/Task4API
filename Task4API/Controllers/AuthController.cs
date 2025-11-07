using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using Task4API.CQRS.CommandDB.Command;
using Task4API.CQRS.CommandDB.DTO;
using Task4API.CQRS.CommandDB.Command;

namespace Task4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Mediator mediator;
        public AuthController(MyMediator.Types.Mediator mediator)
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
