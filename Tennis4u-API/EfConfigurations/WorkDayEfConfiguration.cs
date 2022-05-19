using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class WorkDayEfConfiguration : IEntityTypeConfiguration<WorkDay>
    {
        public void Configure(EntityTypeBuilder<WorkDay> builder)
        {
            builder.ToTable("WorkDay");

            builder.Property(w => w.IdWorkDay).UseIdentityColumn();

            builder.HasKey(w => w.IdWorkDay).HasName("WorkDay_pk");

            builder.Property(w => w.OpenHour).IsRequired();

            builder.Property(w => w.CloseHour).IsRequired();

            builder.HasOne(w => w.IdTenniClubNavigation)
                .WithMany(t => t.WorkDays)
                .HasForeignKey(w => w.IdTennisClub)
                .HasConstraintName("WorkDay_TennisClub");

            builder.HasOne(w => w.IdDayNavigation)
                .WithMany(d => d.WorkDays)
                .HasForeignKey(w => w.IdDay)
                .HasConstraintName("WorkDay_Day");

            var workDays = new List<WorkDay>()
            {
                new WorkDay{IdWorkDay = 1, OpenHour = new TimeSpan(8,0,0), CloseHour = new TimeSpan(22, 0, 0), IdDay = 1, IdTennisClub = 1},
                new WorkDay{IdWorkDay = 2, OpenHour = new TimeSpan(8,0,0), CloseHour = new TimeSpan(22, 0, 0), IdDay = 2, IdTennisClub = 1},
                new WorkDay{IdWorkDay = 3, OpenHour = new TimeSpan(8,0,0), CloseHour = new TimeSpan(22, 0, 0), IdDay = 3, IdTennisClub = 1},
                new WorkDay{IdWorkDay = 4, OpenHour = new TimeSpan(8,0,0), CloseHour = new TimeSpan(22, 0, 0), IdDay = 4, IdTennisClub = 1},
                new WorkDay{IdWorkDay = 5, OpenHour = new TimeSpan(8,0,0), CloseHour = new TimeSpan(22, 0, 0), IdDay = 5, IdTennisClub = 1},
                new WorkDay{IdWorkDay = 6, OpenHour = new TimeSpan(8,0,0), CloseHour = new TimeSpan(22, 0, 0), IdDay = 6, IdTennisClub = 1},
                new WorkDay{IdWorkDay = 7, OpenHour = new TimeSpan(8,0,0), CloseHour = new TimeSpan(22, 0, 0), IdDay = 7, IdTennisClub = 1}
            };

            builder.HasData(workDays);
        }
    }
}
