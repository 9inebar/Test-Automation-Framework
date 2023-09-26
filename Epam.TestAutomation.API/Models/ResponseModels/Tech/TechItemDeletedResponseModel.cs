using Newtonsoft.Json;

namespace Epam.TestAutomation.API.Models.ResponseModels.Tech;

public class TechItemDeletedResponseModel
{
    [JsonProperty("message")]
    public string DeletionMessage { get; set; }
}