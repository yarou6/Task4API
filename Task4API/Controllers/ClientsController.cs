using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Security.Claims;
using Task4API.CQRS.CommandDB.Command;
using Task4API.CQRS.CommandDB.DTO;
using Task4API.DB;
namespace Task4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        IMediator mediator;
        private readonly ItCompany1135Context db;
        public ClientsController(IMediator mediator, ItCompany1135Context db)
        {
            this.mediator = mediator;
            this.db = db;
        }

        [HttpPost("clients/register")]
        public async Task ClientsRegister(ClientDTO clients)
        {
            var command = new ClientsRegisterCommand() { Client = clients, Claim = User.Claims.First()};
            await mediator.SendAsync(command);
            return;
        }

        [HttpPost("clients/deactivate")]
        public async Task ClientDeactivate(string id)
        {
            var command = new DeactivateClientCommand() { Id = id, Claim = User.Claims.First() };
            await mediator.SendAsync(command);
            return;
        }

    }
}
