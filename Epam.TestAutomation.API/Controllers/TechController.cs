using Epam.TestAutomation.API.Models.ResponseModels;
using RestSharp;

namespace Epam.TestAutomation.API.Controllers;

public class TechController : BaseController
{
    public TechController(CustomRestClient client) : base(client, Service.Tech)
    {
        
    }

    private const string AllObjectsResource = "/objects";
    /// <summary>
    /// Gets list of Tech objects from API
    /// </summary>
    /// <typeparam name="T"><see cref="AllTechModel"/></typeparam>
    /// <returns>response info <see cref="RestResponse"/> and <see cref="AllTechModel"/></returns>

    public (RestResponse response, T Objects) GetObjects<T>()
    {
        return Get<T>(AllObjectsResource)!;
    }
}