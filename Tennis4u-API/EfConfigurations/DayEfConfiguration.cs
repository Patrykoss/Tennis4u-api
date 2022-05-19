using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class DayEfConfiguration : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.ToTable("Day");

            builder.HasKey(d => d.IdDay).HasName("Day_pk");

            builder.Property(d => d.IdDay).UseIdentityColumn();

            builder.Property(d => d.Name).HasMaxLength(12).IsRequired();

            var days = new List<Day>()
            {
                new Day {IdDay = 1, Name = "Poniedziałek"},
                new Day {IdDay = 2, Name = "Wtorek"},
                new Day {IdDay = 3, Name = "Środa"},
                new Day {IdDay = 4, Name = "Czwartek"},
                new Day {IdDay = 5, Name = "Piątek"},
                new Day {IdDay = 6, Name = "Sobota"},
                new Day {IdDay = 7, Name = "Niedziela"}
            };

            builder.HasData(days);
        }
    }
}
