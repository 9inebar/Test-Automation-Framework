using System.Text.Json.Serialization;

namespace Epam.TestAutomation.Tests.DDT.Models;

//Check that search results are related to the selected skills
public class SelectSkillsModel
{
    [JsonPropertyName("SearchSkill")]
    public static string SearchSkill;    
    [JsonPropertyName("SearchResult")]
    public static string SearchResult;
}