using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class RoleEfConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(r => r.IdRole).HasName("Role_pk");

            builder.Property(r => r.IdRole).UseIdentityColumn();

            builder.Property(r => r.Name).HasMaxLength(20).IsRequired();

            var roles = new List<Role>()
            {
                new Role {IdRole = 1, Name = "Manager"},
                new Role {IdRole = 2, Name = "Worker"}
            };

            builder.HasData(roles);
        }
    }
}
