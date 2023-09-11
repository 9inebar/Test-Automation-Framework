using System.Text.Json.Serialization;

namespace Epam.TestAutomation.Tests.DDT.Models;

public class KeyWordAndLocationModel
{
    [JsonPropertyName("SearchPhrase")]
    public static string SearchPhrase;
    [JsonPropertyName("SearchCountry")]
    public static string SearchCountry;    
    [JsonPropertyName("SearchCity")]
    public static string SearchCity; 
    [JsonPropertyName("SearchResult")]
    public static string SearchResult;
}