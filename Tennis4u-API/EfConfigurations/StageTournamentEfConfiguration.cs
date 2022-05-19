using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class StageTournamentEfConfiguration : IEntityTypeConfiguration<StageTournament>
    {
        public void Configure(EntityTypeBuilder<StageTournament> builder)
        {
            builder.ToTable("StageTournament");

            builder.HasKey(s => s.IdStageTournament).HasName("StageTournament_pk");

            builder.Property(s => s.Name).HasMaxLength(20).IsRequired();

            var tournamentStages = new List<StageTournament>()
            {
                new StageTournament {IdStageTournament = 1, Name = "Finał"},
                new StageTournament {IdStageTournament = 2, Name = "Półfinał"},
                new StageTournament {IdStageTournament = 3, Name = "Ćwierćfinał"},
                new StageTournament {IdStageTournament = 4, Name = "1/16"},
                new StageTournament {IdStageTournament = 5, Name = "1/32"},
                new StageTournament {IdStageTournament = 6, Name = "1/64"},
                new StageTournament {IdStageTournament = 7, Name = "1/128"},
            };

            builder.HasData(tournamentStages);
        }
    }
}
