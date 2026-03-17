namespace Memos.Console2.Helpers;

using Memos.Console2.Models;

/// <summary>
/// Heper to call SWAPI.
/// </summary>
public static class StarWarsHelper
{
    /// <summary>
    /// Method to map the pilots from a planet to a response with their starships.
    /// </summary>
    /// <param name="planet">Planet.</param>
    /// <returns></returns>
    public static object GetPlanetStarshipResponse(Planet planet)
    {
        var response = new
        {
            PlanetName = planet.Name,
            Pilots = planet.Residents.Select(x =>
        new
        {
            x.Name,
            Starships = x.Starships.Select(s => new
            {
                s.Name,
                s.Manufacturer,
                s.StarshipClass
            }).ToList()
        })
        };

        return response;
    }

    /// <summary>
    /// Method 
    /// </summary>
    /// <param name="planetName"></param>
    /// <returns></returns>
    public static async Task<Planet> GetStarshipsFromPlanetAsync(string planetName)
    {
        using var httpClient = new HttpClient();

        var planets = await ApiResponse<Planet>.GetAllAsync(httpClient, new HttpRequestMessage(HttpMethod.Get, $"https://swapi.dev/api/planets/?search={planetName}"));

        if (planets.Success)
        {
            foreach (var planet in planets.Results)
            {
                foreach (var residentUrl in planet.ResidentUrls)
                {
                    var residentResponse = await ApiResponse<Resident>.GetAllAsync(httpClient, new HttpRequestMessage(HttpMethod.Get, residentUrl));
                    if (residentResponse.Success)
                    {
                        planet.Residents.AddRange(residentResponse.Results.Where(t => t.StarshipsUrls.Count > 0));
                    }
                }

                foreach (var resident in planet.Residents)
                {
                    foreach (var starshipUrl in resident.StarshipsUrls)
                    {
                        var starshipResponse = await ApiResponse<Starship>.GetAllAsync(httpClient, new HttpRequestMessage(HttpMethod.Get, starshipUrl));
                        if (starshipResponse.Success)
                        {
                            resident.Starships.AddRange(starshipResponse.Results);
                        }
                    }
                }
            }
        }

        return planets.Results.FirstOrDefault() ?? new Planet();
    }
}
