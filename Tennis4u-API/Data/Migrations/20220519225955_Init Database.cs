using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tennis4u_API.Data.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    IdDay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Day_pk", x => x.IdDay);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    RefreshTokenExp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Role_pk", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Roof",
                columns: table => new
                {
                    IdRoof = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Roof_pk", x => x.IdRoof);
                });

            migrationBuilder.CreateTable(
                name: "StageTournament",
                columns: table => new
                {
                    IdStageTournament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("StageTournament_pk", x => x.IdStageTournament);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    IdState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("State_pk", x => x.IdState);
                });

            migrationBuilder.CreateTable(
                name: "Surface",
                columns: table => new
                {
                    IdSurface = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Surface_pk", x => x.IdSurface);
                });

            migrationBuilder.CreateTable(
                name: "TennisClub",
                columns: table => new
                {
                    IdTennisClub = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumbers = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TennisClub_pk", x => x.IdTennisClub);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_Client_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateTable(
                name: "TennisCourt",
                columns: table => new
                {
                    IdTennisCourt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsLight = table.Column<bool>(type: "bit", nullable: false),
                    IdSurface = table.Column<int>(type: "int", nullable: false),
                    IdRoof = table.Column<int>(type: "int", nullable: false),
                    IdTennisClub = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TennisCourt", x => x.IdTennisCourt);
                    table.ForeignKey(
                        name: "TennisCourt_Roof",
                        column: x => x.IdRoof,
                        principalTable: "Roof",
                        principalColumn: "IdRoof",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "TennisCourt_Surface",
                        column: x => x.IdSurface,
                        principalTable: "Surface",
                        principalColumn: "IdSurface",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "TennisCourt_TennisClub",
                        column: x => x.IdTennisClub,
                        principalTable: "TennisClub",
                        principalColumn: "IdTennisClub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    IdTournament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaxNumberOfPlayers = table.Column<int>(type: "int", nullable: false),
                    FinalDateForRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTennisClub = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Tournament_pk", x => x.IdTournament);
                    table.ForeignKey(
                        name: "Tournament_TennisClub",
                        column: x => x.IdTennisClub,
                        principalTable: "TennisClub",
                        principalColumn: "IdTennisClub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkDay",
                columns: table => new
                {
                    IdWorkDay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenHour = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseHour = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdDay = table.Column<int>(type: "int", nullable: false),
                    IdTennisClub = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WorkDay_pk", x => x.IdWorkDay);
                    table.ForeignKey(
                        name: "WorkDay_Day",
                        column: x => x.IdDay,
                        principalTable: "Day",
                        principalColumn: "IdDay",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "WorkDay_TennisClub",
                        column: x => x.IdTennisClub,
                        principalTable: "TennisClub",
                        principalColumn: "IdTennisClub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    IdTennisClub = table.Column<int>(type: "int", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_Worker_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "Worker_Role",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Worker_TennisClub",
                        column: x => x.IdTennisClub,
                        principalTable: "TennisClub",
                        principalColumn: "IdTennisClub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClayCourt",
                columns: table => new
                {
                    IdTennisCourt = table.Column<int>(type: "int", nullable: false),
                    ClayColor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClayCourt", x => x.IdTennisCourt);
                    table.ForeignKey(
                        name: "FK_ClayCourt_TennisCourt_IdTennisCourt",
                        column: x => x.IdTennisCourt,
                        principalTable: "TennisCourt",
                        principalColumn: "IdTennisCourt");
                });

            migrationBuilder.CreateTable(
                name: "GrassCourt",
                columns: table => new
                {
                    IdTennisCourt = table.Column<int>(type: "int", nullable: false),
                    HeightOfGrass = table.Column<double>(type: "float", nullable: false),
                    IsNatural = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrassCourt", x => x.IdTennisCourt);
                    table.ForeignKey(
                        name: "FK_GrassCourt_TennisCourt_IdTennisCourt",
                        column: x => x.IdTennisCourt,
                        principalTable: "TennisCourt",
                        principalColumn: "IdTennisCourt");
                });

            migrationBuilder.CreateTable(
                name: "HardCourt",
                columns: table => new
                {
                    IdTennisCourt = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardCourt", x => x.IdTennisCourt);
                    table.ForeignKey(
                        name: "FK_HardCourt_TennisCourt_IdTennisCourt",
                        column: x => x.IdTennisCourt,
                        principalTable: "TennisCourt",
                        principalColumn: "IdTennisCourt");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTennisCourt = table.Column<int>(type: "int", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Reservation_pk", x => x.IdReservation);
                    table.ForeignKey(
                        name: "Reservation_Client",
                        column: x => x.IdPerson,
                        principalTable: "Client",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "Reservation_State",
                        column: x => x.IdState,
                        principalTable: "State",
                        principalColumn: "IdState",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Reservation_TennisCourt",
                        column: x => x.IdTennisCourt,
                        principalTable: "TennisCourt",
                        principalColumn: "IdTennisCourt",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdTournament = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Registration_pk", x => new { x.IdTournament, x.IdClient });
                    table.ForeignKey(
                        name: "Registration_Client",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Registration_Tournament",
                        column: x => x.IdTournament,
                        principalTable: "Tournament",
                        principalColumn: "IdTournament",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    IdMatch = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClientOne = table.Column<int>(type: "int", nullable: true),
                    IdClientTwo = table.Column<int>(type: "int", nullable: true),
                    IdWinner = table.Column<int>(type: "int", nullable: true),
                    IdTournament = table.Column<int>(type: "int", nullable: false),
                    IdStage = table.Column<int>(type: "int", nullable: false),
                    IdReservation = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Match_pk", x => x.IdMatch);
                    table.ForeignKey(
                        name: "FK_Match_Client_IdClientTwo",
                        column: x => x.IdClientTwo,
                        principalTable: "Client",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "Match_ClientOne",
                        column: x => x.IdClientOne,
                        principalTable: "Client",
                        principalColumn: "IdPerson");
                    table.ForeignKey(
                        name: "Match_Reservation",
                        column: x => x.IdReservation,
                        principalTable: "Reservation",
                        principalColumn: "IdReservation");
                    table.ForeignKey(
                        name: "Match_StageTournament",
                        column: x => x.IdStage,
                        principalTable: "StageTournament",
                        principalColumn: "IdStageTournament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Match_Tournament",
                        column: x => x.IdTournament,
                        principalTable: "Tournament",
                        principalColumn: "IdTournament",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Day",
                columns: new[] { "IdDay", "Name" },
                values: new object[,]
                {
                    { 1, "Poniedziałek" },
                    { 2, "Wtorek" },
                    { 3, "Środa" },
                    { 4, "Czwartek" },
                    { 5, "Piątek" },
                    { 6, "Sobota" },
                    { 7, "Niedziela" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "IdPerson", "Email", "FirstName", "LastName", "Password", "RefreshToken", "RefreshTokenExp" },
                values: new object[,]
                {
                    { 2, "j.kowalski@gmail.com", "Jan", "Kowalski", "12341234", null, null },
                    { 3, "m.kowalski@gmail.com", "Michał", "Kowalski", "12341234", null, null },
                    { 4, "b.kowalski@gmail.com", "Bartek", "Kowalski", "12341234", null, null },
                    { 5, "s.kowalski@gmail.com", "Szymon", "Kowalski", "12341234", null, null },
                    { 6, "t.kowalski@gmail.com", "Tymek", "Kowalski", "12341234", null, null },
                    { 7, "m.kowalska@gmail.com", "Magda", "Kowalska", "12341234", null, null },
                    { 8, "o.kowalska@gmail.com", "Ola", "Kowalska", "12341234", null, null },
                    { 9, "e.kowalska@gmail.com", "Ewa", "Kowalska", "16341234", null, null },
                    { 1, "r.kowalski@gmail.com", "Roman", "Kowalski", "72341234", null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "IdRole", "Name" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Worker" }
                });

            migrationBuilder.InsertData(
                table: "Roof",
                columns: new[] { "IdRoof", "Name" },
                values: new object[,]
                {
                    { 1, "Hala" },
                    { 2, "Balon" },
                    { 3, "Kort otwarty" }
                });

            migrationBuilder.InsertData(
                table: "StageTournament",
                columns: new[] { "IdStageTournament", "Name" },
                values: new object[,]
                {
                    { 1, "Finał" },
                    { 2, "Półfinał" },
                    { 3, "Ćwierćfinał" },
                    { 4, "1/16" },
                    { 5, "1/32" },
                    { 6, "1/64" },
                    { 7, "1/128" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "IdState", "Name" },
                values: new object[,]
                {
                    { 1, "opłacona" },
                    { 2, "nieopłacona" },
                    { 3, "odwołana" }
                });

            migrationBuilder.InsertData(
                table: "Surface",
                columns: new[] { "IdSurface", "Name" },
                values: new object[,]
                {
                    { 1, "Mączka" },
                    { 2, "Trawa" },
                    { 3, "Hard" }
                });

            migrationBuilder.InsertData(
                table: "TennisClub",
                columns: new[] { "IdTennisClub", "City", "Email", "Logo", "Name", "PhoneNumbers", "PostCode", "Street", "Website" },
                values: new object[] { 1, "Warszawa", "kontakt@stc.com", "https://images.pexels.com/photos/209977/pexels-photo-209977.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "STC Szkolna Tennis Club", "123123123, 913134122", "12-123", "Szkolna 34", null });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdPerson", "Avatar", "DateOfBirth", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, "https://cdn.pixabay.com/photo/2017/10/11/12/38/sport-2840947_960_720.png", new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "123123123" },
                    { 3, null, null, "123123124" },
                    { 4, null, null, "123123125" },
                    { 5, null, null, "123123126" },
                    { 6, null, null, "123123127" },
                    { 7, null, null, "123123128" },
                    { 8, null, null, "123123129" },
                    { 9, null, null, "123166129" }
                });

            migrationBuilder.InsertData(
                table: "TennisCourt",
                columns: new[] { "IdTennisCourt", "IdRoof", "IdSurface", "IdTennisClub", "IsLight", "Number", "Price" },
                values: new object[,]
                {
                    { 1, 2, 1, 1, true, 1, 70m },
                    { 2, 3, 1, 1, true, 2, 70m },
                    { 3, 1, 2, 1, true, 3, 70m },
                    { 4, 1, 3, 1, false, 4, 50m }
                });

            migrationBuilder.InsertData(
                table: "Tournament",
                columns: new[] { "IdTournament", "EndDate", "FinalDateForRegistration", "IdTennisClub", "MaxNumberOfPlayers", "Name", "Rank", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "STC Masters", 1, new DateTime(2022, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 6, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 24, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "ETC Masters", 1, new DateTime(2022, 6, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "WorkDay",
                columns: new[] { "IdWorkDay", "CloseHour", "IdDay", "IdTennisClub", "OpenHour" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 22, 0, 0, 0), 1, 1, new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(0, 22, 0, 0, 0), 2, 1, new TimeSpan(0, 8, 0, 0, 0) },
                    { 3, new TimeSpan(0, 22, 0, 0, 0), 3, 1, new TimeSpan(0, 8, 0, 0, 0) },
                    { 4, new TimeSpan(0, 22, 0, 0, 0), 4, 1, new TimeSpan(0, 8, 0, 0, 0) },
                    { 5, new TimeSpan(0, 22, 0, 0, 0), 5, 1, new TimeSpan(0, 8, 0, 0, 0) },
                    { 6, new TimeSpan(0, 22, 0, 0, 0), 6, 1, new TimeSpan(0, 8, 0, 0, 0) },
                    { 7, new TimeSpan(0, 22, 0, 0, 0), 7, 1, new TimeSpan(0, 8, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Worker",
                columns: new[] { "IdPerson", "IdRole", "IdTennisClub" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "ClayCourt",
                columns: new[] { "IdTennisCourt", "ClayColor", "Material" },
                values: new object[,]
                {
                    { 1, "orange", "ceglana" },
                    { 2, "blue", "ceglana" }
                });

            migrationBuilder.InsertData(
                table: "GrassCourt",
                columns: new[] { "IdTennisCourt", "HeightOfGrass", "IsNatural" },
                values: new object[] { 3, 2.2000000000000002, false });

            migrationBuilder.InsertData(
                table: "HardCourt",
                columns: new[] { "IdTennisCourt", "Material" },
                values: new object[] { 4, "novacrylic" });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "IdMatch", "IdClientOne", "IdClientTwo", "IdReservation", "IdStage", "IdTournament", "IdWinner", "Result" },
                values: new object[,]
                {
                    { 8, null, null, null, 3, 2, null, null },
                    { 9, null, null, null, 3, 2, null, null },
                    { 10, null, null, null, 3, 2, null, null },
                    { 11, null, null, null, 3, 2, null, null },
                    { 12, null, null, null, 2, 2, null, null },
                    { 13, null, null, null, 2, 2, null, null },
                    { 14, null, null, null, 1, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "IdClient", "IdTournament" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "IdReservation", "EndDate", "IdPerson", "IdState", "IdTennisCourt", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, new DateTime(2022, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 5, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2022, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 5, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, new DateTime(2022, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 5, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 4, new DateTime(2022, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 5, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, new DateTime(2022, 5, 7, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 5, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 2, new DateTime(2022, 5, 7, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 5, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, new DateTime(2022, 5, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 6, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 2, new DateTime(2022, 6, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2022, 6, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, 3, new DateTime(2022, 6, 25, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2022, 6, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 3, new DateTime(2022, 6, 30, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2022, 5, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 3, new DateTime(2022, 5, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2022, 5, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 3, new DateTime(2022, 5, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "IdMatch", "IdClientOne", "IdClientTwo", "IdReservation", "IdStage", "IdTournament", "IdWinner", "Result" },
                values: new object[,]
                {
                    { 1, 2, 3, 1, 3, 1, 2, "6/2 7/6(7:5)" },
                    { 2, 4, 5, 2, 3, 1, 4, "6/3 6/4" },
                    { 3, 6, 7, 3, 3, 1, 6, "6/2 2/6 7/6(7:5)" },
                    { 4, 8, 9, 4, 3, 1, 8, "6/1 6/1" },
                    { 5, 2, 4, 5, 2, 1, 2, "6/2 6/3" },
                    { 6, 6, 8, 6, 2, 1, 6, "6/2 7/6(7:5)" },
                    { 7, 2, 6, 7, 1, 1, 2, "6/2 1/6 7/5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_PhoneNumber",
                table: "Client",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Match_IdClientOne",
                table: "Match",
                column: "IdClientOne");

            migrationBuilder.CreateIndex(
                name: "IX_Match_IdClientTwo",
                table: "Match",
                column: "IdClientTwo");

            migrationBuilder.CreateIndex(
                name: "IX_Match_IdReservation",
                table: "Match",
                column: "IdReservation",
                unique: true,
                filter: "[IdReservation] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Match_IdStage",
                table: "Match",
                column: "IdStage");

            migrationBuilder.CreateIndex(
                name: "IX_Match_IdTournament",
                table: "Match",
                column: "IdTournament");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_RefreshToken",
                table: "Person",
                column: "RefreshToken",
                unique: true,
                filter: "[RefreshToken] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_IdClient",
                table: "Registration",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdPerson",
                table: "Reservation",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdState",
                table: "Reservation",
                column: "IdState");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdTennisCourt_StartDate_IdState",
                table: "Reservation",
                columns: new[] { "IdTennisCourt", "StartDate", "IdState" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TennisCourt_IdRoof",
                table: "TennisCourt",
                column: "IdRoof");

            migrationBuilder.CreateIndex(
                name: "IX_TennisCourt_IdSurface",
                table: "TennisCourt",
                column: "IdSurface");

            migrationBuilder.CreateIndex(
                name: "IX_TennisCourt_IdTennisClub",
                table: "TennisCourt",
                column: "IdTennisClub");

            migrationBuilder.CreateIndex(
                name: "IX_TennisCourt_Number_IdTennisClub",
                table: "TennisCourt",
                columns: new[] { "Number", "IdTennisClub" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_IdTennisClub",
                table: "Tournament",
                column: "IdTennisClub");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDay_IdDay",
                table: "WorkDay",
                column: "IdDay");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDay_IdTennisClub",
                table: "WorkDay",
                column: "IdTennisClub");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_IdRole",
                table: "Worker",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_IdTennisClub",
                table: "Worker",
                column: "IdTennisClub");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClayCourt");

            migrationBuilder.DropTable(
                name: "GrassCourt");

            migrationBuilder.DropTable(
                name: "HardCourt");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "WorkDay");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "StageTournament");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "TennisCourt");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Roof");

            migrationBuilder.DropTable(
                name: "Surface");

            migrationBuilder.DropTable(
                name: "TennisClub");
        }
    }
}
