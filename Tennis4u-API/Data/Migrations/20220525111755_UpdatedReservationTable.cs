using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tennis4u_API.Data.Migrations
{
    public partial class UpdatedReservationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservation_IdTennisCourt_StartDate_IdState",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Reservation",
                newName: "ReservationDate");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndReservation",
                table: "Reservation",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartReservation",
                table: "Reservation",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 1,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 2,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 3,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 4,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 5,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 6,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 17, 0, 0, 0), new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 7,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), new DateTime(2022, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 8,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 9,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 10,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 11,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 14, 0, 0, 0), new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 12,
                columns: new[] { "EndReservation", "ReservationDate", "StartReservation" },
                values: new object[] { new TimeSpan(0, 12, 0, 0, 0), new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdTennisCourt_ReservationDate_StartReservation_IdState",
                table: "Reservation",
                columns: new[] { "IdTennisCourt", "ReservationDate", "StartReservation", "IdState" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservation_IdTennisCourt_ReservationDate_StartReservation_IdState",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "EndReservation",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "StartReservation",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Reservation",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 7, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 7, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 6, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 6, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 6, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 30, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 11,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 12,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 5, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdTennisCourt_StartDate_IdState",
                table: "Reservation",
                columns: new[] { "IdTennisCourt", "StartDate", "IdState" },
                unique: true);
        }
    }
}
