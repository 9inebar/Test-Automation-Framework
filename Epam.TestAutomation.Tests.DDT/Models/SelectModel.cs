using System.Text.Json.Serialization;

namespace Epam.TestAutomation.Tests.DDT.Models;

//Check that search results are related to the selected country and city
public class SelectModel
{
    [JsonPropertyName("SearchCountry")]
    public static string SearchCountry;    
    [JsonPropertyName("SearchCity")]
    public static string SearchCity;
    [JsonPropertyName("SearchResult")]
    public static string SearchResult;
}