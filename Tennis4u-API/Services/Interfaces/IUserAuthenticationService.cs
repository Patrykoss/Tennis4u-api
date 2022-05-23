using Tennis4u_API.Utils;

namespace Tennis4u_API.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        bool VerifyUserPassword(string password, User user);
    }
}
