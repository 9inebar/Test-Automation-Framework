using Epam.TestAutomation.API.Models.SharedModels;
using Newtonsoft.Json;

namespace Epam.TestAutomation.API.Models.ResponseModels.Tech;

public class TechItemPatchUpdateResponseModel
{
    [JsonProperty("id")]
    public string id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("data")]
    public TechData Data { get; set; }

    [JsonProperty("updatedAt")]
    public DateTime UpdatedAt { get; set; }
}