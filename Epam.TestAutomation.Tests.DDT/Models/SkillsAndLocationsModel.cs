using System.Text.Json.Serialization;

namespace Epam.TestAutomation.Tests.DDT.Models;

public class SkillsAndLocationsModel
{
    [JsonPropertyName("SearchPhrase")]
    public static string SearchPhrase;
    [JsonPropertyName("SearchCountry")]
    public static string SearchCountry;    
    [JsonPropertyName("SearchCity")]
    public static string SearchCity;
    [JsonPropertyName("SearchSkill")]
    public static string SearchSkill;
    [JsonPropertyName("SearchResult")]
    public static string SearchResult;
}