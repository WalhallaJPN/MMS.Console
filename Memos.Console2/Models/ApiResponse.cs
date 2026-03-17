namespace Memos.Console2.Models;

using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Response to SWAPI 
/// </summary>
/// <typeparam name="T">Type of response</typeparam>
public class ApiResponse<T> where T : class
{
    #region Properties

    /// <summary>
    /// Count of items in the response.
    /// </summary>
    [JsonProperty("count")]
    public int Count { get; set; }

    /// <summary>
    /// Next page URL.
    /// </summary>
    [JsonProperty("next")]
    public string? Next { get; set; }

    /// <summary>
    /// Previous page URL.
    /// </summary>
    [JsonProperty("previous")]
    public string? Previous { get; set; }

    /// <summary>
    /// List of items in the response.
    /// </summary>
    [JsonProperty("results")]
    public List<T> Results { get; set; } = [];

    #endregion

    #region Public Methods

    /// <summary>
    /// Method to send request and return response of given type.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    /// <param name="client">HttpClient.</param>
    /// <param name="request">Request.</param>
    /// <returns></returns>
    public static async Task<(bool Success, List<T> Results, string? Error)> GetAllAsync(HttpClient client, HttpRequestMessage request)
    {
        var allResults = new List<T>();

        try
        {
            var currentRequest = request;

            while (currentRequest is not null)
            {
                var response = await client.SendAsync(currentRequest);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return (false, [], $"{response.StatusCode} ({(int)response.StatusCode}) : {responseContent}");
                }

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);

                if (apiResponse is not null && (apiResponse.Count > 0 || apiResponse.Results.Count > 0 || apiResponse.Next is not null || apiResponse.Previous is not null))
                {
                    allResults.AddRange(apiResponse.Results);
                    currentRequest = !string.IsNullOrWhiteSpace(apiResponse?.Next) ? new HttpRequestMessage(HttpMethod.Get, apiResponse.Next) : null;

                    continue;
                }

                var singleResult = JsonConvert.DeserializeObject<T>(responseContent);

                if (singleResult is not null)
                {
                    allResults.Add(singleResult);
                    return (true, allResults, null);
                }

                return (false, [], $"Response could not be deserialized as ApiResponse<T> or T");
            }

            return (true, allResults, null);
        }
        catch (Exception ex)
        {
            return (false, [], $"Exception: {ex.Message}");
        }
    }

    #endregion
}
