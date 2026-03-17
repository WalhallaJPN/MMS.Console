using Memos.Console2.Helpers;
using Newtonsoft.Json;

// SW REST Api

var planetName = "Kashyyyk";

var planet = StarWarsHelper.GetStarshipsFromPlanetAsync(planetName).GetAwaiter().GetResult();
var response = StarWarsHelper.GetPlanetStarshipResponse(planet);

var jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);

Console.WriteLine(jsonResponse);
Console.ReadLine();