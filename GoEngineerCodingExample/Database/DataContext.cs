using GoEngineerCodingExample.Models;
using Microsoft.EntityFrameworkCore;

namespace GoEngineerCodingExample.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<StarShipModel> StarShips { get; set; }
        public DbSet<PeopleModel> People { get; set; }
        public DbSet<PlanetModel> Planets { get; set; }
        public DbSet<FilmModel> Films { get; set; }
        public DbSet<SpeciesModel> Species { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
    }
}
