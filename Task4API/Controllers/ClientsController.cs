using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;
using Task4API.DB;
using Task4API.CQRS.CommandDB.Command;
using Task4API.CQRS.CommandDB.DTO;
namespace Task4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly Mediator mediator;
        public ClientsController(MyMediator.Types.Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("clients/register")]
        public async Task<string> ClientsRegister(string login, string password)
        {
            var command = new ClientsRegisterCommand() { Login = login, Password = password};
            await mediator.SendAsync(command);
            return;
        }

    }
}
