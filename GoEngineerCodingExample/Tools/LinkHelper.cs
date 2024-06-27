using GoEngineerCodingExample.Models;

namespace GoEngineerCodingExample.Tools
{
    public class LinkHelper
    {
        public static List<LinkModel> GetFilmLinks(List<FilmModel> filmModels)
        {
            List<LinkModel> links = new List<LinkModel>();
            foreach (FilmModel filmModel in filmModels)
            {
                links.Add(new LinkModel { Id = filmModel.Id, Name = filmModel.title });
            }

            return links;
        }

        public static List<LinkModel> GetPersonLinks(List<PeopleModel> peopleModels)
        {
            List<LinkModel> links = new List<LinkModel>();
            foreach (PeopleModel peopleModel in peopleModels)
            {
                links.Add(new LinkModel { Id = peopleModel.Id, Name = peopleModel.name });
            }

            return links;
        }

        public static List<LinkModel> GetPlanetLinks(List<PlanetModel> planetModels)
        {
            List<LinkModel> links = new List<LinkModel>();
            foreach (PlanetModel planetModel in planetModels)
            {
                links.Add(new LinkModel { Id = planetModel.Id, Name = planetModel.name });
            }

            return links;
        }

        public static List<LinkModel> GetStarShipLinks(List<StarShipModel> starShipModels)
        {
            List<LinkModel> links = new List<LinkModel>();
            foreach (StarShipModel starshipModel in starShipModels)
            {
                links.Add(new LinkModel { Id = starshipModel.Id, Name = starshipModel.name });
            }

            return links;
        }

        public static List<LinkModel> GetVehicleLinks(List<VehicleModel> vehicleModels)
        {
            List<LinkModel> links = new List<LinkModel>();
            foreach (VehicleModel vehicleModel in vehicleModels)
            {
                links.Add(new LinkModel { Id = vehicleModel.Id, Name = vehicleModel.name });
            }

            return links;
        }

        public static List<LinkModel> GetSpeciesLinks(List<SpeciesModel> speciesModels)
        {
            List<LinkModel> links = new List<LinkModel>();
            foreach (SpeciesModel speciesModel in speciesModels)
            {
                links.Add(new LinkModel { Id = speciesModel.Id, Name = speciesModel.name });
            }

            return links;
        }

        public static LinkModel GetPlanetLink(PlanetModel planetModel)
        {
            return new LinkModel { Id = planetModel.Id, Name = planetModel.name };
        }

        public static LinkModel GetSpeciesLink(SpeciesModel speciesModel)
        {
            return new LinkModel { Id = speciesModel.Id, Name = speciesModel.name };
        }
    }
}
