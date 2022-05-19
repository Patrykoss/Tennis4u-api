using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class WorkerEfConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Worker");

            builder.HasOne(w => w.IdRoleNavigation)
                .WithMany(r => r.Workers)
                .HasForeignKey(w => w.IdRole)
                .HasConstraintName("Worker_Role");

            builder.HasOne(w => w.IdTennisClubNavigation)
                .WithMany(t => t.Workers)
                .HasForeignKey(w => w.IdTennisClub)
                .HasConstraintName("Worker_TennisClub");


            var workers = new List<Worker>()
            {
                new Worker {IdPerson = 1, FirstName = "Roman", LastName = "Kowalski", Email = "r.kowalski@gmail.com", Password = "72341234", IdTennisClub = 1, IdRole = 1},
                //new Worker {IdPerson = 2, IdTennisClub = 1, IdRole = 2}
            };

            builder.HasData(workers);
        }
    }
}
