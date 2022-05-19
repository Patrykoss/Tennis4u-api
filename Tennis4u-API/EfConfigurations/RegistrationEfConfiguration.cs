using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class RegistrationEfConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("Registration");
            builder.HasKey(r => new { r.IdTournament, r.IdClient }).HasName("Registration_pk");

            builder.HasOne(r => r.IdClientNavigation)
                .WithMany(c => c.Registrations)
                .HasForeignKey(r => r.IdClient)
                .HasConstraintName("Registration_Client");

            builder.HasOne(r => r.IdTournamentNavigation)
                .WithMany(t => t.Registrations)
                .HasForeignKey(r => r.IdTournament)
                .HasConstraintName("Registration_Tournament");

            var registrations = new List<Registration>()
            {
                new Registration {IdTournament = 1, IdClient = 2},
                new Registration {IdTournament = 1, IdClient = 3},
                new Registration {IdTournament = 1, IdClient = 4},
                new Registration {IdTournament = 1, IdClient = 5},
                new Registration {IdTournament = 1, IdClient = 6},
                new Registration {IdTournament = 1, IdClient = 7},
                new Registration {IdTournament = 1, IdClient = 8},
                new Registration {IdTournament = 1, IdClient = 9},
                new Registration {IdTournament = 2, IdClient = 4},
                new Registration {IdTournament = 2, IdClient = 5},
                new Registration {IdTournament = 2, IdClient = 6}
            };

            builder.HasData(registrations);


        }
    }
}
