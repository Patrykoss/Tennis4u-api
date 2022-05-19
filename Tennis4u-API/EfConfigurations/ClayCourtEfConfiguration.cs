using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class ClayCourtEfConfiguration : IEntityTypeConfiguration<ClayCourt>
    {
        public void Configure(EntityTypeBuilder<ClayCourt> builder)
        {
            builder.ToTable("ClayCourt");

            builder.Property(c => c.ClayColor).HasMaxLength(20).IsRequired();

            builder.Property(c => c.Material).HasMaxLength(20).IsRequired();

            var clayCourts = new List<ClayCourt>()
            {
                new ClayCourt { IdTennisCourt = 1, Number = 1, Price = 70, IdRoof = 2, IsLight = true, IdSurface = 1, IdTennisClub = 1, ClayColor = "orange", Material="ceglana"},
                new ClayCourt { IdTennisCourt = 2, Number = 2, Price = 70, IdRoof = 3, IsLight = true, IdSurface = 1, IdTennisClub = 1, ClayColor = "blue", Material="ceglana"}
            };

            builder.HasData(clayCourts);
        }
    }
}
