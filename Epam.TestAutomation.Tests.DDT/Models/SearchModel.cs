using System.Text.Json.Serialization;

namespace Epam.TestAutomation.Tests.DDT.Models;

//Check that search results are related to the selected keyword
public class SearchModel
{
    [JsonPropertyName("SearchPhrase")]
    public string SearchPhrase;    
    [JsonPropertyName("SearchResult")]
    public string SearchResult;
}