using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Task4API.CQRS.CommandDB.DTO;
using Task4API.DB;
namespace Task4API.CQRS.CommandDB.Command
{
    public class ClientsRegisterCommand : IRequest
    {
        public required Claim Claim { get; set; }
        public required ClientDTO Client { get; set; }
        public class ClientsRegisterCommandHandler : IRequestHandler<ClientsRegisterCommand, Unit>
        {
            private readonly ItCompany1135Context db;
            public ClientsRegisterCommandHandler(ItCompany1135Context db)
            {
                this.db = db;
            }
            public async Task<Unit> HandleAsync(ClientsRegisterCommand request, CancellationToken ct = default)
            {
                var claim = request.Claim;
                if (claim.Type != ClaimValueTypes.Sid)
                    return Unit.Value;

                var client = db.Clients.Find(claim.Value);
                if (client == null)
                    return Unit.Value;

                var admin = db.ClientRoles.FirstOrDefault(s => s.ClientId == client.Sid);
                if (admin.RoleId != 1 || admin == null)
                    return Unit.Value;


                db.Clients.Add(new Client 
                { 
                    Login =  request.Client.Login, 
                    Password = request.Client.Password, 
                    Email = request.Client.Email, 
                    PhoneNumber = request.Client.PhoneNumber,
                    FirstName = request.Client.FirstName,
                    LastName = request.Client.LastName,
                    Department = request.Client.Department,
                    Position = request.Client.Position,
                    IsActive = request.Client.IsActive,
                    LastLoginAt = request.Client.LastLoginAt,
                    IsDeleted = request.Client.IsDeleted,
                    DeletedAt = request.Client.DeletedAt,
                    DeletedBy = request.Client.DeletedBy,
                    CreatedAt = request.Client.CreatedAt,
                    CreatedBy = request.Client.CreatedBy,
                    ModifiedAt = request.Client.ModifiedAt,
                    ModifiedBy = request.Client.ModifiedBy

                });
                db.SaveChanges();

                return Unit.Value;
            }
        }
    }

}
