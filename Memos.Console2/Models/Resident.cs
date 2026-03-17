namespace Memos.Console2.Models;

using Newtonsoft.Json;

/// <summary>
/// Resident model (partial).
/// </summary>
public class Resident
{
    /// <summary>
    /// Name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Height.
    /// </summary>
    [JsonProperty("height")]
    public int Height { get; set; }

    /// <summary>
    /// Starships URLs.
    /// </summary>
    [JsonProperty("starships")]
    public List<string> StarshipsUrls { get; set; } = [];

    /// <summary>
    /// Models of Starships.
    /// </summary>
    [JsonIgnore]
    public List<Starship> Starships { get; set; } = [];
}
