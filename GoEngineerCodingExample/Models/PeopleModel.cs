using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEngineerCodingExample.Models
{
    public class PeopleModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Height (CM)")]
        public string height { get; set; }

        [Display(Name = "Mass (KG)")]
        public string mass { get; set; }

        [Display(Name = "Hair Color")]
        public string hair_color { get; set; }

        [Display(Name = "Skin Color")]
        public string skin_color { get; set; }

        [Display(Name = "Eye Color")]
        public string eye_color { get; set; }

        [Display(Name = "Birth Year")]
        public string birth_year { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "Homeworld")]
        public string? homeworld { get; set; }

        [Display(Name = "Films")]
        public List<string>? films { get; set; }

        [Display(Name = "Species")]
        public List<string>? species { get; set; }

        [Display(Name = "Vehicles")]
        public List<string>? vehicles { get; set; }

        [Display(Name = "Starships")]
        public List<string>? starships { get; set; }

        [Display(Name = "Record Created")]
        public DateTime created { get; set; }

        [Display(Name = "Record Edited")]
        public DateTime edited { get; set; }

        [Display(Name = "SWAPI URL")]
        public string url { get; set; }

        [NotMapped]
        public LinkModel? HomeworldLink { get; set; }

        [NotMapped]
        public List<LinkModel>? SpeciesLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? FilmLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? StarShipLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? VehicleLinks { get; set; }

        [NotMapped]
        public List<PlanetModel>? HomeworldOptions { get; set; }

        [NotMapped]
        public List<FilmModel>? FilmOptions { get; set; }

        [NotMapped]
        public List<StarShipModel>? StarShipOptions { get; set; }

        [NotMapped]
        public List<VehicleModel>? VehicleOptions { get; set; }

        [NotMapped]
        public List<SpeciesModel>? SpeciesOptions { get; set; }
    }
}
