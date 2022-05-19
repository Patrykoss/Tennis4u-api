using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class MatchEfConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Match");

            builder.HasKey(m => m.IdMatch).HasName("Match_pk");

            builder.Property(m => m.IdMatch).UseIdentityColumn();

            builder.Property(m => m.IdClientOne).IsRequired(false);

            builder.Property(m => m.IdClientTwo).IsRequired(false);

            builder.Property(m => m.IdWinner).IsRequired(false);

            builder.Property(m => m.IdReservation).IsRequired(false);

            builder.HasOne(m => m.IdClientOneNavigation)
                .WithMany(c => c.MatchesOne)
                .HasForeignKey(m => m.IdClientOne)
                .HasConstraintName("Match_ClientOne");

            builder.HasOne(m => m.IdClientTwoNavigation)
                .WithMany(c => c.MatchesTwo)
                .HasForeignKey(m => m.IdClientTwo);

            builder.HasOne(m => m.IdTournamentNavigation)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.IdTournament)
                .HasConstraintName("Match_Tournament");

            builder.HasOne(m => m.IdStageTournamentNavigation)
                .WithMany(s => s.Matches)
                .HasForeignKey(m => m.IdStage)
                .HasConstraintName("Match_StageTournament");

            builder.HasOne(m => m.IdReservationNavigation)
                .WithOne(r => r.IdMatchNavigation)
                .HasForeignKey<Match>(m => m.IdReservation)
                .HasConstraintName("Match_Reservation");

            var matches = new List<Match>()
            {
                new Match {IdMatch = 1, IdClientOne = 2, IdClientTwo = 3, IdWinner = 2, IdTournament = 1, IdStage = 3, IdReservation = 1, Result = "6/2 7/6(7:5)"},
                new Match {IdMatch = 2, IdClientOne = 4, IdClientTwo = 5, IdWinner = 4, IdTournament = 1, IdStage = 3, IdReservation = 2, Result = "6/3 6/4"},
                new Match {IdMatch = 3, IdClientOne = 6, IdClientTwo = 7, IdWinner = 6, IdTournament = 1, IdStage = 3, IdReservation = 3, Result = "6/2 2/6 7/6(7:5)"},
                new Match {IdMatch = 4, IdClientOne = 8, IdClientTwo = 9, IdWinner = 8, IdTournament = 1, IdStage = 3, IdReservation = 4, Result = "6/1 6/1"},
                new Match {IdMatch = 5, IdClientOne = 2, IdClientTwo = 4, IdWinner = 2, IdTournament = 1, IdStage = 2, IdReservation = 5, Result = "6/2 6/3"},
                new Match {IdMatch = 6, IdClientOne = 6, IdClientTwo = 8, IdWinner = 6, IdTournament = 1, IdStage = 2, IdReservation = 6, Result = "6/2 7/6(7:5)"},
                new Match {IdMatch = 7, IdClientOne = 2, IdClientTwo = 6, IdWinner = 2, IdTournament = 1, IdStage = 1, IdReservation = 7, Result = "6/2 1/6 7/5"},
                new Match {IdMatch = 8, IdClientOne = null, IdClientTwo = null, IdWinner = null, IdTournament = 2, IdStage = 3, IdReservation = null, Result = null},
                new Match {IdMatch = 9, IdClientOne = null, IdClientTwo = null, IdWinner = null, IdTournament = 2, IdStage = 3, IdReservation = null, Result = null},
                new Match {IdMatch = 10, IdClientOne = null, IdClientTwo = null, IdWinner = null, IdTournament = 2, IdStage = 3, IdReservation = null, Result = null},
                new Match {IdMatch = 11, IdClientOne = null, IdClientTwo = null, IdWinner = null, IdTournament = 2, IdStage = 3, IdReservation = null, Result = null},
                new Match {IdMatch = 12, IdClientOne = null, IdClientTwo = null, IdWinner = null, IdTournament = 2, IdStage = 2, IdReservation = null, Result = null},
                new Match {IdMatch = 13, IdClientOne = null, IdClientTwo = null, IdWinner = null, IdTournament = 2, IdStage = 2, IdReservation = null, Result = null},
                new Match {IdMatch = 14, IdClientOne = null, IdClientTwo = null, IdWinner = null, IdTournament = 2, IdStage = 1, IdReservation = null, Result = null},
            };

            builder.HasData(matches);
        }
    }
}
