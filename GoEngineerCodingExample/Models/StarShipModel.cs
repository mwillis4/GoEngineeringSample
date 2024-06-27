using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoEngineerCodingExample.Models
{
	public class StarShipModel
	{
		public int Id { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Model")]
        public string model { get; set; }

        [Display(Name = "Manufacturer")]
        public string manufacturer { get; set; }

        [Display(Name = "Cost in Credits")]
        public string cost_in_credits { get; set; }

        [Display(Name = "Length (M)")]
        public string length { get; set; }

        [Display(Name = "Max Speed Within Atmosphere (KPH)")]
        public string max_atmosphering_speed { get; set; }

        [Display(Name = "Full Crew")]
        public string crew { get; set; }

        [Display(Name = "Max Passengers")]
        public string passengers { get; set; }

        [Display(Name = "Cargo Capacity")]
        public string cargo_capacity { get; set; }

        [Display(Name = "Consumables")]
        public string consumables { get; set; }

        [Display(Name = "Hyperdrive Rating")]
        public string hyperdrive_rating { get; set; }

        [Display(Name = "MGLT (Megalight per Hour)")]
        public string MGLT { get; set; }

        [Display(Name = "Class")]
        public string starship_class { get; set; }

        [Display(Name = "Pilots")]
        public List<string>? pilots { get; set; }

        [Display(Name = "Films")]
        public List<string>? films { get; set; }

        [Display(Name = "Record Created")]
        public DateTime created { get; set; }

        [Display(Name = "Record Edited")]
        public DateTime edited { get; set; }

        [Display(Name = "SWAPI URL")]
        public string url { get; set; }

        [NotMapped]
        public List<LinkModel>? PilotLinks { get; set; }

        [NotMapped]
        public List<LinkModel>? FilmLinks { get; set; }

        [NotMapped]
        public List<FilmModel>? FilmOptions { get; set; }

        [NotMapped]
        public List<PeopleModel>? PilotOptions { get; set; }
    }
}
