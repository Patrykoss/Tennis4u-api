using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class RoofEfConfiguration : IEntityTypeConfiguration<Roof>
    {
        public void Configure(EntityTypeBuilder<Roof> builder)
        {
            builder.ToTable("Roof");

            builder.HasKey(r => r.IdRoof).HasName("Roof_pk");

            builder.Property(r => r.IdRoof).UseIdentityColumn();

            builder.Property(r => r.Name).HasMaxLength(15).IsRequired();

            var roofs = new List<Roof>()
            {
                new Roof {IdRoof = 1, Name = "Hala"},
                new Roof {IdRoof = 2, Name = "Balon"},
                new Roof {IdRoof = 3, Name = "Kort otwarty"},
            };

            builder.HasData(roofs);
        }
    }
}
