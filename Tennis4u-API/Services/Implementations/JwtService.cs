using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tennis4u_API.Models.Configs;
using Tennis4u_API.Services.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly JwtConfigModel _jwtConfigModel;

        public JwtService(IOptionsMonitor<JwtConfigModel> optionsMonitor)
        {
            _jwtConfigModel = optionsMonitor.CurrentValue;
        }

        public (string refreshToken, DateTime refreshTokenExp) GenerateRefreshToken()
        {
            var refreshToken = Guid.NewGuid().ToString();
            var refreshTokenExp = DateTime.Now.AddMinutes(_jwtConfigModel.RefreshTokenValidityInMinutes);
            return (refreshToken, refreshTokenExp);
        }

        public JwtSecurityToken GenerateAccessToken(User user)
        {
            var userClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.IdPerson.ToString()),
            };
            if(user.RoleInClubName is not null)
                userClaims.Add(new(ClaimTypes.Role, user.RoleInClubName));
            
            if(user.IsClient)
                userClaims.Add(new(ClaimTypes.Role, "Client"));

            if (user.IdClub is not null)
                userClaims.Add(new(ClaimTypes.GroupSid, user.IdClub.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfigModel.SecretKey));

            return new JwtSecurityToken(
                issuer: _jwtConfigModel.Issuer,
                audience: _jwtConfigModel.Audience,
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(_jwtConfigModel.AccessTokenValidityInMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
        }

        public string WriteToken(SecurityToken securityToken)
        {
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
