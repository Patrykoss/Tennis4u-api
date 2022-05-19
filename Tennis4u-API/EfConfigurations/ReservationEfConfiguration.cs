﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tennis4u_API.Models;

namespace Tennis4u_API.EfConfigurations
{
    public class ReservationEfConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.HasKey(r => r.IdReservation).HasName("Reservation_pk");

            builder.Property(r => r.IdReservation).UseIdentityColumn();

            builder.Property(r => r.StartDate).IsRequired();

            builder.Property(r => r.EndDate).IsRequired();

            builder.Property(r => r.IdPerson).IsRequired(false);

            builder.HasIndex(r => new { r.IdTennisCourt, r.StartDate, r.IdState }).IsUnique();

            builder.HasOne(r => r.IdTennisCourtNavigation)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.IdTennisCourt)
                .HasConstraintName("Reservation_TennisCourt");

            builder.HasOne(r => r.IdClientNavigation)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.IdPerson)
                .HasConstraintName("Reservation_Client");

            builder.HasOne(r => r.IdStateNavigation)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.IdState)
                .HasConstraintName("Reservation_State");

            var reservations = new List<Reservation>()
            {
                new Reservation {IdReservation = 1, IdTennisCourt = 1, IdPerson = null, IdState = 1, StartDate = new DateTime(2022,5,7,12,0,0), EndDate = new DateTime(2022,5,7,14,0,0)},
                new Reservation {IdReservation = 2, IdTennisCourt = 2, IdPerson = null, IdState = 1, StartDate = new DateTime(2022,5,7,12,0,0), EndDate = new DateTime(2022,5,7,14,0,0)},
                new Reservation {IdReservation = 3, IdTennisCourt = 3, IdPerson = null, IdState = 1, StartDate = new DateTime(2022,5,7,12,0,0), EndDate = new DateTime(2022,5,7,14,0,0)},
                new Reservation {IdReservation = 4, IdTennisCourt = 4, IdPerson = null, IdState = 1, StartDate = new DateTime(2022,5,7,12,0,0), EndDate = new DateTime(2022,5,7,14,0,0)},
                new Reservation {IdReservation = 5, IdTennisCourt = 1, IdPerson = null, IdState = 1, StartDate = new DateTime(2022,5,7,15,0,0), EndDate = new DateTime(2022,5,7,17,0,0)},
                new Reservation {IdReservation = 6, IdTennisCourt = 2, IdPerson = null, IdState = 1, StartDate = new DateTime(2022,5,7,15,0,0), EndDate = new DateTime(2022,5,7,17,0,0)},
                new Reservation {IdReservation = 7, IdTennisCourt = 1, IdPerson = null, IdState = 1, StartDate = new DateTime(2022,5,8,18,0,0), EndDate = new DateTime(2022,5,8,20,0,0)},
                new Reservation {IdReservation = 8, IdTennisCourt = 2, IdPerson = 6, IdState = 2, StartDate = new DateTime(2022,6,25,12,0,0), EndDate = new DateTime(2022,6,25,14,0,0)},
                new Reservation {IdReservation = 9, IdTennisCourt = 3, IdPerson = 7, IdState = 2, StartDate = new DateTime(2022,6,25,12,0,0), EndDate = new DateTime(2022,6,25,14,0,0)},
                new Reservation {IdReservation = 10, IdTennisCourt = 3, IdPerson = 3, IdState = 2, StartDate = new DateTime(2022,6,30,18,0,0), EndDate = new DateTime(2022,6,30,20,0,0)},
                new Reservation {IdReservation = 11, IdTennisCourt = 3, IdPerson = 3, IdState = 1, StartDate = new DateTime(2022,5,5,12,0,0), EndDate = new DateTime(2022,5,5,14,0,0)},
                new Reservation {IdReservation = 12, IdTennisCourt = 3, IdPerson = 3, IdState = 3, StartDate = new DateTime(2022,5,5,10,0,0), EndDate = new DateTime(2022,5,5,12,0,0)}
            };

            builder.HasData(reservations);

        }
    }
}
