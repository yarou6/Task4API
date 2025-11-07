using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Text.RegularExpressions;
using Task4API.CQRS.CommandDB.DTO;
using Task4API.DB;
namespace Task4API.CQRS.CommandDB.Command
{
    public class ClientsRegisterCommand : IRequest<string>
    {
        public required string Password { get; set; }
        public required string Login { get; set; }
        public class ClientsRegisterCommandHandler : IRequestHandler<ClientsRegisterCommand, string>
        {
            private readonly ItCompany1135Context db;
            public ClientsRegisterCommandHandler(ItCompany1135Context db)
            {
                this.db = db;
            }
            public async Task<string> HandleAsync(ClientsRegisterCommand request, CancellationToken ct = default)
            {
                var client = db.Clients.FirstOrDefaultAsync()


                return;
            }
        }
    }

}
