using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using MyMediator.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Task4API.CQRS.CommandDB.DTO;
using Task4API.DB;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Task4API.CQRS.CommandDB.Command
{
    public class LoginCommand : IRequest<string>
    {
        public required LoginData Data { get; set; }
        public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
        {
            private readonly ItCompany1135Context db;
            public LoginCommandHandler(ItCompany1135Context db)
            {
                this.db = db;
            }
            public async Task<string> HandleAsync(LoginCommand request, CancellationToken ct = default)
            {
                var client = db.Clients.FirstOrDefault(s => s.Login == request.Data.Login
                && s.Password == request.Data.Password);

                if (client == null)
                    return null;

                var claims = new List<Claim> {
                new Claim(ClaimValueTypes.Sid, client.Sid),
            };

                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                string token = new JwtSecurityTokenHandler().WriteToken(jwt);

                return token;

            }
        }
    }
   
}
