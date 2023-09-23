using System.Text.Json.Serialization;

namespace Epam.TestAutomation.Tests.DDT.Models;
//Check that search results are related to the selected keyword and location
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