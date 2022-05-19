using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class SurfaceEfConfiguration : IEntityTypeConfiguration<Surface>
    {
        public void Configure(EntityTypeBuilder<Surface> builder)
        {
            builder.ToTable("Surface");

            builder.HasKey(s => s.IdSurface).HasName("Surface_pk");

            builder.Property(s => s.IdSurface).UseIdentityColumn();

            builder.Property(s => s.Name).HasMaxLength(20).IsRequired();

            var surfaces = new List<Surface>()
            {
                new Surface { IdSurface = 1, Name = "Mączka"},
                new Surface { IdSurface = 2, Name = "Trawa"},
                new Surface { IdSurface = 3, Name = "Hard"},
            };

            builder.HasData(surfaces);
        }
    }
}
