using Epam.TestAutomation.API.Models.SharedModels;

namespace Epam.TestAutomation.API.Models.ResponseModels;

public class TechItemSingleResponseModel
{
    public string id { get; set; }
    public string name { get; set; }
    public TechData data { get; set; }
    public string createdAt { get; set; }
}