using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class HardCourtEfConfiguration : IEntityTypeConfiguration<HardCourt>
    {
        public void Configure(EntityTypeBuilder<HardCourt> builder)
        {
            builder.ToTable("HardCourt");

            builder.Property(h => h.Material).HasMaxLength(30).IsRequired();

            var hardCourts = new List<HardCourt>()
            {
                new HardCourt { IdTennisCourt = 4, Number = 4, Price = 50, IdRoof = 1, IsLight = false, IdSurface = 3, IdTennisClub = 1, Material="novacrylic"}
            };

            builder.HasData(hardCourts);
        }
    }
}
