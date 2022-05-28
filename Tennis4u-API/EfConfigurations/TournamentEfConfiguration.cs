using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class TournamentEfConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.ToTable("Tournament");

            builder.HasKey(t => t.IdTournament).HasName("Tournament_pk");

            builder.Property(t => t.IdTournament).UseIdentityColumn();

            builder.Property(t => t.Name).IsRequired();

            builder.Property(t => t.StartDate).IsRequired();

            builder.Property(t => t.FinalDateForRegistration).IsRequired();

            builder.HasOne(t => t.IdTennisClubNavigation)
                .WithMany(tc => tc.Tournaments)
                .HasForeignKey(t => t.IdTennisClub)
                .HasConstraintName("Tournament_TennisClub");

            var tournaments = new List<Tournament>()
            {
                new Tournament  {IdTournament = 1, Name = "STC Masters", MaxNumberOfPlayers = 8, IdTennisClub = 1, Rank = 1, StartDate = new DateTime(2022,5,7,12,0,0), EndDate = new DateTime(2022,5,8,20,0,0), FinalDateForRegistration = new DateTime(2022,5,4,19,0,0)},
                new Tournament  {IdTournament = 2, Name = "ETC Masters", MaxNumberOfPlayers = 8, IdTennisClub = 1, Rank = 1, StartDate = new DateTime(2022,6,25,12,0,0), EndDate = new DateTime(2022,6,26,20,0,0), FinalDateForRegistration = new DateTime(2022,6,24,19,0,0)}
            };

            builder.HasData(tournaments);
        }
    }
}
