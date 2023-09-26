using Newtonsoft.Json;

namespace Epam.TestAutomation.API.Models.SharedModels;

public class TechData
{
    [JsonProperty("color")]
    public string Color { get; set; }

    [JsonProperty("capacity")]
    public string Capacity { get; set; }

    [JsonProperty("capacityGB")]
    public int CapacityGB { get; set; }

    [JsonProperty("price")]
    public float Price { get; set; }

    [JsonProperty("generation")]
    public string Generation { get; set; }

    [JsonProperty("year")]
    public int Year { get; set; }

    [JsonProperty("CPUmodel")]
    public string CPUmodel { get; set; }

    [JsonProperty("hardDiskSize")]
    public string Harddisksize { get; set; }

    [JsonProperty("StrapColour")]
    public string StrapColour { get; set; }

    [JsonProperty("CaseSize")]
    public string CaseSize { get; set; }

    [JsonProperty("Description")]
    public string Description { get; set; }

    [JsonProperty("ScreenSize")]
    public float Screensize { get; set; }
}