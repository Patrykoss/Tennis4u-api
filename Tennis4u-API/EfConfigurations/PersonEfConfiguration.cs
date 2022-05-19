using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class PersonEfConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(p => p.IdPerson);

            builder.Property(p => p.IdPerson).UseIdentityColumn();

            builder.Property(p => p.FirstName).HasMaxLength(30).IsRequired();

            builder.Property(p => p.LastName).HasMaxLength(30).IsRequired();

            builder.Property(p => p.Email).HasMaxLength(30).IsRequired();

            builder.HasIndex(p => p.Email).IsUnique();

            builder.Property(p => p.Password).IsRequired();

            builder.Property(p => p.RefreshToken).HasMaxLength(36).IsRequired(false);

            builder.HasIndex(p => p.RefreshToken).IsUnique();

            builder.Property(p => p.RefreshTokenExp).IsRequired(false);
        }
    }
}
