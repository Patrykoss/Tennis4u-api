using Microsoft.AspNetCore.Identity;
using Tennis4u_API.Services.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Services.Implementations
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public bool VerifyUserPassword(string password, User user)
        {
            return !(new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Failed);
        }
    }
}
