using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserStatus> AddNewUserAsync(RegisterRequestDTO registerDTO);
        Task<User?> GetUserByEmail(LoginRequestDTO loginDTO);
        Task<UserStatus> UpdateUserRefreshToken(User user, string refreshToken, DateTime refreshTokenExp);
    }
}
