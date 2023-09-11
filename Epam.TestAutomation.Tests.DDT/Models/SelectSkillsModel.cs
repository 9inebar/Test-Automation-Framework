using System.Text.Json.Serialization;

namespace Epam.TestAutomation.Tests.DDT.Models;

public class SelectSkillsModel
{
    [JsonPropertyName("SearchSkill")]
    public static string SearchSkill;    
    [JsonPropertyName("SearchResult")]
    public static string SearchResult;
}