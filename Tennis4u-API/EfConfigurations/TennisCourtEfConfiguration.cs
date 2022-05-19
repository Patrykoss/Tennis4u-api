using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class TennisCourtEfConfiguration : IEntityTypeConfiguration<TennisCourt>
    {
        public void Configure(EntityTypeBuilder<TennisCourt> builder)
        {
            builder.ToTable("TennisCourt");

            builder.HasKey(t => t.IdTennisCourt);

            builder.HasIndex(t => new { t.Number, t.IdTennisClub }).IsUnique();

            builder.HasOne(t => t.IdTennisClubNavigation)
                .WithMany(tc => tc.TennisCourts)
                .HasForeignKey(t => t.IdTennisClub)
                .HasConstraintName("TennisCourt_TennisClub");

            builder.HasOne(t => t.IdSurfaceNavigation)
                .WithMany(s => s.TennisCourts)
                .HasForeignKey(t => t.IdSurface)
                .HasConstraintName("TennisCourt_Surface");

            builder.HasOne(t => t.IdRoofNavigation)
                .WithMany(r => r.TennisCourts)
                .HasForeignKey(t => t.IdRoof)
                .HasConstraintName("TennisCourt_Roof");

            /*var TennisCourts = new List<TennisCourt>()
            {
                new TennisCourt {IdTennisCourt = 1, Number = 1, Price = 70, IdRoof = 2, IsLight = true, IdSurface = 1, IdTennisClub = 1},
                new TennisCourt {IdTennisCourt = 2, Number = 2, Price = 70, IdRoof = 3, IsLight = true, IdSurface = 1, IdTennisClub = 1},
                new TennisCourt {IdTennisCourt = 3, Number = 3, Price = 70, IdRoof = 1, IsLight = true, IdSurface = 2, IdTennisClub = 1},
                new TennisCourt {IdTennisCourt = 4, Number = 4, Price = 50, IdRoof = 1, IsLight = false, IdSurface = 3, IdTennisClub = 1},
            };

            builder.HasData(TennisCourts);*/

        }
    }
}
