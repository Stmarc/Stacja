using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stacja = table.Column<string>(type: "TEXT", nullable: false),
                    DataPomiaru = table.Column<string>(type: "TEXT", nullable: false),
                    GodzinaPomiaru = table.Column<string>(type: "TEXT", nullable: false),
                    Temperatura = table.Column<float>(type: "REAL", nullable: false),
                    PredkoscWiatru = table.Column<float>(type: "REAL", nullable: false),
                    KierunekWiatru = table.Column<string>(type: "TEXT", nullable: false),
                    WilgotnoscWzgledna = table.Column<float>(type: "REAL", nullable: false),
                    SumaOpadu = table.Column<float>(type: "REAL", nullable: false),
                    Cisnienie = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}
