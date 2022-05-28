using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Interfaces
{
    public interface IWorkerRepository
    {
        Task<UserStatus> CreateWorkerAsync(WorkerCreateRequestDTO workerDto, int idClub);
    }
}
