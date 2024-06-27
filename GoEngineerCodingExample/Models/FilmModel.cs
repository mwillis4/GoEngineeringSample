using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEngineerCodingExample.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Episode Id")]
        public int episode_id { get; set; }

        [Display(Name = "Opening Crawl")]
        public string opening_crawl { get; set; }

        [Display(Name = "Director")]
        public string director { get; set; }

        [Display(Name = "Producer")]
        public string producer { get; set; }

        [Display(Name = "Release Date")]
        public string release_date { get; set; }

        [Display(Name = "Characters")]
        public List<string>? characters { get; set; }

        [Display(Name = "Planets")]
        public List<string>? planets { get; set; }

        [Display(Name = "Star Ships")]
        public List<string>? starships { get; set; }

        [Display(Name = "Vehicles")]
        public List<string>? vehicles { get; set; }

        [Display(Name = "Species")]
        public List<string>? species { get; set; }

        [Display(Name = "Record Created")]
        public DateTime created { get; set; }

        [Display(Name = "Record Edited")]
        public DateTime edited { get; set; }

        [Display(Name = "SWAPI URL")]
        public string url { get; set; }

        [NotMapped]
        public List<LinkModel>? CharacterLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? PlanetLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? StarShipLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? VehicleLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? SpeciesLinks { get; set; }

        [NotMapped]
        public List<PeopleModel>? CharacterOptions { get; set; }

        [NotMapped]
        public List<PlanetModel>? PlanetOptions { get; set; }

        [NotMapped]
        public List<StarShipModel>? StarShipOptions { get; set; }

        [NotMapped]
        public List<VehicleModel>? VehicleOptions { get; set; }

        [NotMapped]
        public List<SpeciesModel>? SpeciesOptions { get; set; }
    }
}
