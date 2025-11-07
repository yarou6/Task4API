using MyMediator.Interfaces;
using MyMediator.Types;
using System.Security.Claims;
using Task4API.CQRS.CommandDB.DTO;
using Task4API.DB;

namespace Task4API.CQRS.CommandDB.Command
{
    public class DeactivateClientCommand : IRequest
    {
        public required Claim Claim { get; set; }
        public required string Id { get; set; }
        public class DeactivateClientCommandHandler : IRequestHandler<DeactivateClientCommand, Unit>
        {
            private readonly ItCompany1135Context db;
            public DeactivateClientCommandHandler(ItCompany1135Context db)
            {
                this.db = db;
            }
            public async Task<Unit> HandleAsync(DeactivateClientCommand request, CancellationToken ct = default)
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

                db.Clients.Where(s => s.Sid == request.Id).Select(s => 
                {
                    IsActive = s.IsActive,
                });



                return Unit.Value;
            }
        }
    }
}
