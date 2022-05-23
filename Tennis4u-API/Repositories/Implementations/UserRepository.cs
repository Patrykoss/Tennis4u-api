using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.Models;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserStatus> AddNewUserAsync(RegisterRequestDTO registerDTO)
        {
            var emailIsTaken = await _context.Persons.AnyAsync(p => p.Email == registerDTO.Email);

            if (emailIsTaken)
                return UserStatus.EmailNotAvailable;

            var phoneNumberIsTaken = await _context.Clients.AnyAsync(p => p.PhoneNumber == registerDTO.PhoneNumber);

            if (phoneNumberIsTaken)
                return UserStatus.PhoneNumberNotAvailable;

            var client = new Client
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                Avatar = registerDTO.Avatar,
                DateOfBirth = registerDTO.DateOfBirth,
            };

            client.Password = new PasswordHasher<Client>().HashPassword(client, registerDTO.Password);

            await _context.Clients.AddAsync(client);

            var isSaved = await _context.SaveChangesAsync();
            return isSaved > 0 ? UserStatus.UserAdded : UserStatus.DbError;
        }

        public async Task<User?> GetUserByEmail(LoginRequestDTO loginDTO)
        {
            return await _context.Persons.Where(p => p.Email == loginDTO.Email).Select(p => new User
            {
                IdPerson = p.IdPerson,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Password = p.Password,
                Avatar = ((Client)p).Avatar,
                RoleInClubName = ((Worker)p).IdRoleNavigation.Name,
                IsClient = p is Client,
                IdClub = p is Worker ? ((Worker)p).IdTennisClub : null
            }).SingleOrDefaultAsync(); ;
        }

        public async Task<UserStatus> UpdateUserRefreshToken(User user, string refreshToken, DateTime refreshTokenExp)
        {
            var person = await _context.Persons.SingleOrDefaultAsync(p => p.IdPerson == user.IdPerson);
            person.RefreshToken = refreshToken;
            person.RefreshTokenExp = refreshTokenExp;
            return await _context.SaveChangesAsync() > 0? UserStatus.RefreshTokenAdded : UserStatus.DbError;
        }
    }
}
