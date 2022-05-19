using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class StateEfConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");

            builder.HasKey(s => s.IdState).HasName("State_pk");

            builder.Property(s => s.IdState).UseIdentityColumn();

            builder.Property(s => s.Name).HasMaxLength(11).IsRequired();

            var states = new List<State>()
            {
                new State {IdState = 1, Name = "opłacona"},
                new State {IdState = 2, Name = "nieopłacona"},
                new State {IdState = 3, Name = "odwołana"},
            };

            builder.HasData(states);
        }
    }
}
