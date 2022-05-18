using Microsoft.EntityFrameworkCore;

namespace Tennis4u_API.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
