using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trucking.Migrations
{
    public partial class inittruckingdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Truckers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompleteName = table.Column<string>(type: "TEXT", nullable: true),
                    TruckerType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truckers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Source = table.Column<string>(type: "TEXT", nullable: true),
                    Destiny = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    TripStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    TruckerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Truckers_TruckerId",
                        column: x => x.TruckerId,
                        principalTable: "Truckers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Truckers",
                columns: new[] { "Id", "CompleteName", "TruckerType" },
                values: new object[] { 1, "Juan Gomez", "Carga Seca" });

            migrationBuilder.InsertData(
                table: "Truckers",
                columns: new[] { "Id", "CompleteName", "TruckerType" },
                values: new object[] { 2, "Martin Suarez", "Autos" });

            migrationBuilder.InsertData(
                table: "Truckers",
                columns: new[] { "Id", "CompleteName", "TruckerType" },
                values: new object[] { 3, "Agustin Ramirez", "Ganaderia" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "Destiny", "Source", "TripStatus", "TruckerId" },
                values: new object[] { 1, "Viaje de ...", "CABA, Buenos Aires", "Rosario, Santa Fe", 0, 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "Destiny", "Source", "TripStatus", "TruckerId" },
                values: new object[] { 2, "Viaje de ...", "Bariloche, Rio Negro", "Arroyo Seco, Buenos Aires", 1, 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "Destiny", "Source", "TripStatus", "TruckerId" },
                values: new object[] { 3, "Viaje de ...", "Carlos Paz, Cordoba", "Rosario, Santa Fe", 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TruckerId",
                table: "Trips",
                column: "TruckerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Truckers");
        }
    }
}
