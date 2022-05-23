using Microsoft.EntityFrameworkCore;
using Tennis4u_API.EfConfigurations;
using Tennis4u_API.Models;

namespace Tennis4u_API.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<ClayCourt> ClayCourts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<GrassCourt> GrassCourts { get; set; }
        public virtual DbSet<HardCourt> HardCourts { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Roof> Roofs { get; set; }
        public virtual DbSet<StageTournament> StageTournaments { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Surface> Surfaces { get; set; }
        public virtual DbSet<TennisClub> TennisClubs { get; set; }
        public virtual DbSet<TennisCourt> TennisCourts { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<WorkDay> WorkDays { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClayCourtEfConfiguration());
            modelBuilder.ApplyConfiguration(new ClientEfConfiguration());
            modelBuilder.ApplyConfiguration(new DayEfConfiguration());
            modelBuilder.ApplyConfiguration(new GrassCourtEfConfiguration());
            modelBuilder.ApplyConfiguration(new HardCourtEfConfiguration());
            modelBuilder.ApplyConfiguration(new MatchEfConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEfConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationEfConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationEfConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEfConfiguration());
            modelBuilder.ApplyConfiguration(new RoofEfConfiguration());
            modelBuilder.ApplyConfiguration(new StageTournamentEfConfiguration());
            modelBuilder.ApplyConfiguration(new StateEfConfiguration());
            modelBuilder.ApplyConfiguration(new SurfaceEfConfiguration());
            modelBuilder.ApplyConfiguration(new TennisClubEfConfiguration());
            modelBuilder.ApplyConfiguration(new TennisCourtEfConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentEfConfiguration());
            modelBuilder.ApplyConfiguration(new WorkDayEfConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerEfConfiguration());
        }
    }
}
