namespace Memos.Console2.Models;

using Newtonsoft.Json;

/// <summary>
/// Model of Starship (partial)
/// </summary>
public class Starship
{
    /// <summary>
    /// Name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// MGLT.
    /// </summary>
    [JsonProperty("MGLT")]
    public string MGLT { get; set; }

    /// <summary>
    /// Cargo capacity.
    /// </summary>
    [JsonProperty("cargo_capacity")]
    public string CargoCapacity { get; set; }

    /// <summary>
    /// Created.
    /// </summary>
    [JsonProperty("created")]
    public DateTimeOffset Created { get; set; }

    /// <summary>
    /// Manufacturer.
    /// </summary>
    [JsonProperty("manufacturer")]
    public string Manufacturer { get; set; }

    /// <summary>
    /// Starship class.
    /// </summary>
    [JsonProperty("starship_class")]
    public string StarshipClass { get; set; }
    

}
