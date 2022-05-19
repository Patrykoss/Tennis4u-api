using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class TennisClubEfConfiguration : IEntityTypeConfiguration<TennisClub>
    {
        public void Configure(EntityTypeBuilder<TennisClub> builder)
        {
            builder.ToTable("TennisClub");

            builder.HasKey(t => t.IdTennisClub).HasName("TennisClub_pk");

            builder.Property(t => t.IdTennisClub).UseIdentityColumn();

            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();

            builder.Property(t => t.Email).HasMaxLength(50);

            builder.Property(t => t.Website).HasMaxLength(100);

            builder.Property(t => t.PhoneNumbers).HasMaxLength(100).IsRequired();

            builder.Property(t => t.City).HasMaxLength(30).IsRequired();

            builder.Property(t => t.Street).HasMaxLength(100).IsRequired();

            builder.Property(t => t.PostCode).HasMaxLength(6).IsRequired();

            builder.Property(t => t.Logo).IsRequired();

            var tennisClubs = new List<TennisClub>()
            {
                new TennisClub {IdTennisClub = 1, Name = "STC Szkolna Tennis Club", Email = "kontakt@stc.com", Website = null, PhoneNumbers = "123123123, 913134122", City = "Warszawa", Street = "Szkolna 34", PostCode = "12-123", Logo = "https://images.pexels.com/photos/209977/pexels-photo-209977.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"}
            };

            builder.HasData(tennisClubs);

        }
    }
}
