using Newtonsoft.Json;

namespace Epam.TestAutomation.API.Models.ResponseModels.Tech;

public class TechItemCreatedAtResponseModel : TechItemSingleResponseModel
{
    [JsonProperty("createdAt")]
    public string createdAt { get; set; }
}