using Epam.TestAutomation.API.Models.SharedModels;

namespace Epam.TestAutomation.API.Models.RequestModels;

public class TechItemRequestModel
{
    public string name { get; set; }
    public TechData data { get; set; }
}

