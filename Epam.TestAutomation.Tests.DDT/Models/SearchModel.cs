using System.Text.Json.Serialization;

namespace Epam.TestAutomation.Tests.DDT.Models;

public class SearchModel
{
    [JsonPropertyName("SearchPhrse")]
    public string SearchPhrase;    
    [JsonPropertyName("SearchResult")]
    public string SearchResult;    
    [JsonPropertyName("InformationPageTitle")]
    public string InformationPageTitle;
    
}