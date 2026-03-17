namespace Memos.Console2.Models;

using Newtonsoft.Json;

/// <summary>
/// Planet Model (partial).
/// </summary>
public class Planet
{
    #region Properties

    /// <summary>
    /// Name of the planet.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Residents URLs.
    /// </summary>
    [JsonProperty("residents")]
    public List<string> ResidentUrls { get; set; } = [];

    /// <summary>
    /// Population.
    /// </summary>
    [JsonProperty("population")]
    public int Population { get; set; }

    /// <summary>
    /// Climate.
    /// </summary>
    [JsonProperty("climate")]
    public string Climate { get; set; }

    /// <summary>
    /// Residents.
    /// </summary>
    [JsonIgnore]
    public List<Resident> Residents { get; set; } = [];
    #endregion
}
