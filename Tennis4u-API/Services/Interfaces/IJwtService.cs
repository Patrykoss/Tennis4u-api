using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Services.Interfaces
{
    public interface IJwtService
    {
        (string refreshToken, DateTime refreshTokenExp) GenerateRefreshToken();
        JwtSecurityToken GenerateAccessToken(User user);
        string WriteToken(SecurityToken securityToken);
    }
}
