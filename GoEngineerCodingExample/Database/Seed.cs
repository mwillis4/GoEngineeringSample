using GoEngineerCodingExample.Models;
using System.Text.Json;

namespace GoEngineerCodingExample.Database
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            HttpClient client = new HttpClient();

            if (!context.StarShips.Any())
            {
                await SeedStarShipData(context, client);
            }

            if (!context.People.Any())
            {
                await SeedPeopleData(context, client);
            }

            if (!context.Planets.Any())
            {
                await SeedPlanetData(context, client);
            }

            if (!context.Films.Any())
            {
                await SeedFilmData(context, client);
            }

            if (!context.Species.Any())
            {
                await SeedSpeciesData(context, client);
            }

            if (!context.Vehicles.Any())
            {
                await SeedVehiclesData(context, client);
            }
        }

        private static async Task SeedStarShipData(DataContext context, HttpClient client)
        {

            string path = "https://swapi.dev/api/starships";

            while (!string.IsNullOrEmpty(path))
            {
                HttpResponseMessage response = await client.GetAsync(path);

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    SWAPIStarShipReturnModel? swapiResult = JsonSerializer.Deserialize<SWAPIStarShipReturnModel>(jsonResponse);
                    if (swapiResult != null)
                    {
                        await context.StarShips.AddRangeAsync(swapiResult.results);
                        path = swapiResult.next;
                    }
                }
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedPeopleData(DataContext context, HttpClient client)
        {
            string path = "https://swapi.dev/api/people";

            while (!string.IsNullOrEmpty(path))
            {
                HttpResponseMessage response = await client.GetAsync(path);

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    SWAPIPeopleReturnModel? swapiResult = JsonSerializer.Deserialize<SWAPIPeopleReturnModel>(jsonResponse);
                    if (swapiResult != null)
                    {
                        await context.People.AddRangeAsync(swapiResult.results);
                        path = swapiResult.next;
                    }
                }
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedPlanetData(DataContext context, HttpClient client)
        {
            string path = "https://swapi.dev/api/planets";

            while (!string.IsNullOrEmpty(path))
            {
                HttpResponseMessage response = await client.GetAsync(path);

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    SWAPIPlanetReturnModel? swapiResult = JsonSerializer.Deserialize<SWAPIPlanetReturnModel>(jsonResponse);
                    if (swapiResult != null)
                    {
                        await context.Planets.AddRangeAsync(swapiResult.results);
                        path = swapiResult.next;
                    }
                }
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedFilmData(DataContext context, HttpClient client)
        {
            string path = "https://swapi.dev/api/films";

            while (!string.IsNullOrEmpty(path))
            {
                HttpResponseMessage response = await client.GetAsync(path);

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    SWAPIFilmReturnModel? swapiResult = JsonSerializer.Deserialize<SWAPIFilmReturnModel>(jsonResponse);
                    if (swapiResult != null)
                    {
                        await context.Films.AddRangeAsync(swapiResult.results);
                        path = swapiResult.next;
                    }
                }
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedSpeciesData(DataContext context, HttpClient client)
        {
            string path = "https://swapi.dev/api/species";

            while (!string.IsNullOrEmpty(path))
            {
                HttpResponseMessage response = await client.GetAsync(path);

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    SWAPISpeciesReturnModel? swapiResult = JsonSerializer.Deserialize<SWAPISpeciesReturnModel>(jsonResponse);
                    if (swapiResult != null)
                    {
                        var list = swapiResult.results;
                        await context.Species.AddRangeAsync(swapiResult.results);
                        path = swapiResult.next;
                    }
                }
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedVehiclesData(DataContext context, HttpClient client)
        {
            string path = "https://swapi.dev/api/vehicles";

            while (!string.IsNullOrEmpty(path))
            {
                HttpResponseMessage response = await client.GetAsync(path);

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    SWAPIVehicleReturnModel? swapiResult = JsonSerializer.Deserialize<SWAPIVehicleReturnModel>(jsonResponse);
                    if (swapiResult != null)
                    {
                        var list = swapiResult.results;
                        await context.Vehicles.AddRangeAsync(swapiResult.results);
                        path = swapiResult.next;
                    }
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
