using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class GrassCourtEfConfiguration : IEntityTypeConfiguration<GrassCourt>
    {
        public void Configure(EntityTypeBuilder<GrassCourt> builder)
        {
            builder.ToTable("GrassCourt");

            builder.Property(g => g.IsNatural).IsRequired();

            var grassCourts = new List<GrassCourt>()
            {
                new GrassCourt { IdTennisCourt = 3, Number = 3, Price = 70, IdRoof = 1, IsLight = true, IdSurface = 2, IdTennisClub = 1, IsNatural = false, HeightOfGrass = 2.2}
            };

            builder.HasData(grassCourts);
        }
    }
}
