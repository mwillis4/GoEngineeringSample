using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEngineerCodingExample.Models
{
    public class SpeciesModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Classification")]
        public string classification { get; set; }

        [Display(Name = "Designation")]
        public string designation { get; set; }

        [Display(Name = "Average Height")]
        public string average_height { get; set; }

        [Display(Name = "Skin Colors")]
        public string skin_colors { get; set; }

        [Display(Name = "Hair Colors")]
        public string hair_colors { get; set; }

        [Display(Name = "Eye Colors")]
        public string eye_colors { get; set; }

        [Display(Name = "Average Lifespan")]
        public string average_lifespan { get; set; }

        [Display(Name = "Homeworld")]
        public string? homeworld { get; set; }

        [Display(Name = "Language")]
        public string language { get; set; }

        [Display(Name = "Characters")]
        public List<string>? people { get; set; }

        [Display(Name = "Films")]
        public List<string>? films { get; set; }

        [Display(Name = "Record Created")]
        public DateTime created { get; set; }

        [Display(Name = "Record Edited")]
        public DateTime edited { get; set; }

        [Display(Name = "SWAPI URL")]
        public string url { get; set; }

        [NotMapped]
        public LinkModel? HomeworldLink { get; set; }

        [NotMapped]
        public List<LinkModel>? CharacterLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? FilmLinks { get; set; }

        [NotMapped]
        public List<PlanetModel>? HomeworldOptions { get; set; }

        [NotMapped]
        public List<FilmModel>? FilmOptions { get; set; }

        [NotMapped]
        public List<PeopleModel>? CharacterOptions { get; set; }

    }
}
