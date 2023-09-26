using Epam.TestAutomation.API.Models.RequestModels;
using Epam.TestAutomation.API.Models.ResponseModels.Tech;
using RestSharp;

namespace Epam.TestAutomation.API.Controllers;

public class TechController : BaseController
{
    public TechController(CustomRestClient client) : base(client, Service.Tech)
    {
        
    }

    private const string AllObjectsResource = "/objects";
    private const string SingleObjectResource = "/objects/{0}";
    
    /// <summary>
    /// Gets list of Tech objects from API
    /// </summary>
    /// <typeparam name="T"><see cref="TechItemSingleResponseModel"/></typeparam>
    /// <returns>response info <see cref="RestResponse"/> and <see cref="TechItemSingleResponseModel"/></returns>

    public (RestResponse response, T Objects) GetObjects<T>()
    {
        return Get<T>(AllObjectsResource)!;
    }
    
    /// <summary>
    /// Get single object by ID
    /// </summary>
    /// <typeparam name="T"><see cref="TechItemSingleResponseModel"/></typeparam>
    /// <param name="objectId"></param>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="TechItemSingleResponseModel"/></returns>
    public (RestResponse Response, T? Tech) GetSingleTechItem<T>(string objectId) 
    {
        return Get<T>(string.Format(SingleObjectResource, objectId));
    }
    
    /// <summary>
    /// Post new object
    /// </summary>
    /// <typeparam name="T"><see cref="TechItemRequestModel"/></typeparam>
    /// <param name="model"></param>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="TechItemCreatedAtResponseModel"/></returns>
    public (RestResponse Response, T? Tech) AddTechItem<T>(TechItemRequestModel model) 
    {
        return Post<T, TechItemRequestModel>(AllObjectsResource, model); 
    }
    
    /// <summary>
    /// Delete object by ID
    /// </summary>
    /// <typeparam name="T"><see cref="TechItemRequestModel"/></typeparam>
    /// <param name="objectId"></param>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="TechItemDeletedResponseModel"/></returns>
    public (RestResponse Response, T? Tech) DeleteCreatedItem<T>(string objectId) 
    {
        return Delete<T>(string.Format(SingleObjectResource, objectId));
    }

    /// <summary>
    /// Modify object using Patch method
    /// </summary>
    /// <typeparam name="T"><see cref="TechItemRequestModel"/></typeparam>
    /// <param name="objectId"></param>
    /// <param name="patch"></param>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="TechItemPatchUpdateResponseModel"/></returns>
    public (RestResponse Response, T? Tech) PatchTechItem<T>(object patch, string objectId)
    {
        return Patch<T, TechItemRequestModel>(string.Format(SingleObjectResource, objectId), patch);
    }
}