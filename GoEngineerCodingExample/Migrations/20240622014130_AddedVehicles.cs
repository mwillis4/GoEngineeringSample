using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoEngineerCodingExample.Migrations
{
    /// <inheritdoc />
    public partial class AddedVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cost_in_credits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    max_atmosphering_speed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    crew = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passengers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargo_capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    consumables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicle_class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pilots = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    films = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
