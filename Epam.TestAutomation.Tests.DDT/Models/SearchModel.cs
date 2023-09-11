using System.Text.Json.Serialization;

namespace Epam.TestAutomation.Tests.DDT.Models;

public class SearchModel
{
    [JsonPropertyName("SearchPhrase")]
    public string SearchPhrase;    
    [JsonPropertyName("SearchResult")]
    public string SearchResult;
}