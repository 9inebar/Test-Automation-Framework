using Epam.TestAutomation.API.Models.SharedModels;
using Newtonsoft.Json;

namespace Epam.TestAutomation.API.Models.ResponseModels.Tech;

public class TechItemSingleResponseModel
{
    [JsonProperty("id")]
    public string id { get; set; }
    [JsonProperty("name")]
    public string name { get; set; }
    [JsonProperty("data")]
    public TechData data { get; set; }
}