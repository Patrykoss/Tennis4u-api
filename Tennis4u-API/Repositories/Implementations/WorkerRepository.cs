using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.Models;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Implementations
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly AppDbContext _context;

        public WorkerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserStatus> CreateWorkerAsync(WorkerCreateRequestDTO workerDto, int idClub)
        {
            var emailIsTaken = await _context.Persons.AnyAsync(p => p.Email == workerDto.Email);

            if (emailIsTaken)
                return UserStatus.EmailNotAvailable;

            var client = new Worker
            {
                FirstName = workerDto.FirstName,
                LastName = workerDto.LastName,
                Email = workerDto.Email,
                IdRole = 2,
                IdTennisClub = idClub
            };

            client.Password = new PasswordHasher<Worker>().HashPassword(client, workerDto.Password);

            await _context.Workers.AddAsync(client);

            var isSaved = await _context.SaveChangesAsync();
            return isSaved > 0 ? UserStatus.UserAdded : UserStatus.DbError;
        }
    }
}
