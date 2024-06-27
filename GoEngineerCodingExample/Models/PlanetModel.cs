using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEngineerCodingExample.Models
{
    public class PlanetModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Rotation Period")]
        public string rotation_period { get; set; }

        [Display(Name = "Orbital Period")]
        public string orbital_period { get; set; }

        [Display(Name = "Diameter")]
        public string diameter { get; set; }

        [Display(Name = "Climate")]
        public string climate { get; set; }

        [Display(Name = "Gravity")]
        public string gravity { get; set; }

        [Display(Name = "Terrain")]
        public string terrain { get; set; }

        [Display(Name = "Surface Water")]
        public string surface_water { get; set; }

        [Display(Name = "Population")]
        public string population { get; set; }

        [Display(Name = "Residents")]
        public List<string>? residents { get; set; }

        [Display(Name = "Films")]
        public List<string>? films { get; set; }

        [Display(Name = "Record Created")]
        public DateTime created { get; set; }

        [Display(Name = "Record Edited")]
        public DateTime edited { get; set; }

        [Display(Name = "SWAPI URL")]
        public string url { get; set; }

        [NotMapped]
        public List<LinkModel>? ResidentLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? FilmLinks { get; set; }

        [NotMapped]
        public List<FilmModel>? FilmOptions { get; set; }

        [NotMapped]
        public List<PeopleModel>? ResidentOptions { get; set; }
    }
}
