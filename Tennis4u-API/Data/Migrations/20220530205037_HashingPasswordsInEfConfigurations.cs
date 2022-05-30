using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tennis4u_API.Data.Migrations
{
    public partial class HashingPasswordsInEfConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEE8muayti3PWtK+f+Q0ezLZLTAdDKpT21EAqkfa7icGSftUvyAXABsk3AYKTLhR8Fg==");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAuSMRaRRbuKltZBwRt3XE/S14dErl/XGtn1787bUbtfqUvoKR5XJUdjV8/wRSmkyg==");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 4,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEIxLFXvgeOrwzI9DP9FlkwZXHX05p8c2OBLbgS99mWFlNVWOt9NQ8DywFDqdTURZBA==");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 5,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEG8KCudHrBMqy3olIqiRKOZLSW+BITn1AeCapee+Dlx1X+Y62qCAmL28p1h2NKcdQw==");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 6,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEM2GOZ5uig/py2/Ep1t+N7xSzkkjx/nKeQZl+bbsoZo04trmWaZfwiGsuMulBY54YQ==");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 7,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEN5TubWZZr31VyEOAWUQK0wlq1+560g7ex3Ug6SbqMU7Xq3rJA7nG5YUArtATrkjKg==");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 8,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEERoeq1cKqIEqFV10N+XsL2azAXESiiwawOrE3NEJOxjtvG07Hqk8Yw/bMJLXns25w==");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 9,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEObQL33EOiE+N5rqObbzt0CIlecA6v8WZYCDMFFkEzA+Q03+isDBNtiv9Tc4OVR3RQ==");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOASm+77XOQMX2lm9GuSJkFXM+66OedGhHK1pLJHVbhHfNWjnaiv/UzwnI7uCUYDCw==");

            migrationBuilder.UpdateData(
                table: "Tournament",
                keyColumn: "IdTournament",
                keyValue: 1,
                column: "MaxNumberOfPlayers",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Tournament",
                keyColumn: "IdTournament",
                keyValue: 2,
                column: "MaxNumberOfPlayers",
                value: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 2,
                column: "Password",
                value: "12341234");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 3,
                column: "Password",
                value: "12341234");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 4,
                column: "Password",
                value: "12341234");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 5,
                column: "Password",
                value: "12341234");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 6,
                column: "Password",
                value: "12341234");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 7,
                column: "Password",
                value: "12341234");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 8,
                column: "Password",
                value: "12341234");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 9,
                column: "Password",
                value: "16341234");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "IdPerson",
                keyValue: 1,
                column: "Password",
                value: "72341234");

            migrationBuilder.UpdateData(
                table: "Tournament",
                keyColumn: "IdTournament",
                keyValue: 1,
                column: "MaxNumberOfPlayers",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tournament",
                keyColumn: "IdTournament",
                keyValue: 2,
                column: "MaxNumberOfPlayers",
                value: 0);
        }
    }
}
