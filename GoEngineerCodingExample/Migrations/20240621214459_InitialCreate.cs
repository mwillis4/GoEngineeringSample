using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoEngineerCodingExample.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    episode_id = table.Column<int>(type: "int", nullable: false),
                    opening_crawl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    planets = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    starships = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hair_color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skin_color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eye_color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth_year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    homeworld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    films = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    starships = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rotation_period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orbital_period = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diameter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    climate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gravity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    terrain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surface_water = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    population = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    residents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    films = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    average_height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skin_colors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hair_colors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eye_colors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    average_lifespan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    homeworld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    people = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    films = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarShips",
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
                    hyperdrive_rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MGLT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    starship_class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pilots = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    films = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarShips", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "StarShips");
        }
    }
}
