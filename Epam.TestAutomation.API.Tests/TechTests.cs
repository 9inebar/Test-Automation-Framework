using System.Net;
using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.Models.RequestModels;
using Epam.TestAutomation.API.Models.ResponseModels.Tech;
using Epam.TestAutomation.API.Models.SharedModels;
using NUnit.Framework;
using RestSharp;

namespace Epam.TestAutomation.API.Tests;

public class TechTests
{
    [Test]
    public void CheckAllObjectsResponseWithValidParams()
    {
        var response = new TechController(new CustomRestClient()).GetObjects<RestResponse>();
        Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "invalid status code was returned when sending GET request to /objects");
    }

    [Test]
    public void CheckAllObjectsResponseReturnsObject()
    {
        var response = new TechController(new CustomRestClient()).GetObjects<List<TechItemSingleResponseModel>>();
        CollectionAssert.IsNotEmpty(response.Objects, "Any object should be returned when sending GET request to /objects");
    }

    [Test]
    public void CheckThatObjectWithCapacityCanBeCreatedAndDeleted()
    {
        var capacity = 2048;


        var objectCreateRequest = new TechItemRequestModel
        {
            name = "Apple MacBook Pro 16",
            data = new TechData
            {
                Price = 2089,
                CapacityGB = 2048
            }
        };

        var createdObject = new TechController(new CustomRestClient())
            .AddObject<TechItemCreatedAtResponseModel>(objectCreateRequest).Tech;

        var returnedObject = new TechController(new CustomRestClient())
            .GetObject<TechItemSingleResponseModel>(createdObject.id).Tech;

        var deletedObject = new TechController(new CustomRestClient())
            .DeleteObject<TechItemDeletedResponseModel>(createdObject.id).Tech;

        Assert.That(returnedObject.data.CapacityGB, Is.EqualTo(capacity), "Object fields don't match");
        Assert.That(deletedObject.DeletionMessage.Contains(createdObject.id), "the object is not deleted");
    }

    [Test]
    public void CheckThatObjectCanBeDeleted()
    {

        var objectCreateRequest = new TechItemRequestModel
        {
            name = "Apple iPhone 14 Pro",
            data = new TechData
            {
                Price = 1300,
                Generation = "14"
            }
        };

        var createdObject = new TechController(new CustomRestClient())
            .AddObject<TechItemCreatedAtResponseModel>(objectCreateRequest).Tech;

        var returnedObject = new TechController(new CustomRestClient())
            .GetObject<TechItemSingleResponseModel>(createdObject.id).Tech;

        var deleteObject = new TechController(new CustomRestClient())
            .DeleteObject<TechItemDeletedResponseModel>(createdObject.id).Tech;

        var deletedObject = new TechController(new CustomRestClient())
            .GetObject<TechItemSingleResponseModel>(createdObject.id).Tech;

        Assert.That(deletedObject.id, Is.Null, "Item is not deleted");
    }
    
    [Test]
    public void CheckThatObjectCanBePatched()
    {
        var newPrice = 2000;

        var objectCreateRequest = new TechItemRequestModel
        {
            name = "iPhone 14",
            data = new TechData
            {
                Price = 1789,
                CapacityGB = 1024
            }
        };

        var patch = new
        {
            Data = new 
            {
                Price = 2000
            }
        };

        var createdObject = new TechController(new CustomRestClient()).AddObject<TechItemCreatedAtResponseModel>(objectCreateRequest).Tech;

        var returnedObject = new TechController(new CustomRestClient()).GetObject<TechItemSingleResponseModel>(createdObject.id).Tech;

        var patchedObject = new TechController(new CustomRestClient()).PatchObject<TechItemPatchUpdateResponseModel>(patch, createdObject.id).Tech;

        var deletedObject = new TechController(new CustomRestClient()).DeleteObject<TechItemDeletedResponseModel>(createdObject.id).Tech;

        Assert.That(patchedObject.Data.Price, Is.EqualTo(newPrice), "Updated value should match");
        Assert.That(deletedObject.DeletionMessage.Contains(createdObject.id), "the object is not deleted");
    }
    
    [Test]
    public void CheckThatObjectCanBePut()
    {
        var price = 2000;

        var objectCreateRequest = new TechItemRequestModel
        {
            name = "Apple MacBook Pro 16",
            data = new TechData
            {
                Year = 2019,
                Price = 2049,
                CapacityGB = 1024,
                Harddisksize = "1 TB",
                Color = "silver"
            }
        };

        var put = new TechItemRequestModel
        {
            name = "Apple MacBook Pro 16",
            data = new TechData
            {
                Year = 2019,
                Price = 2000,
                CapacityGB = 1024,
                Harddisksize = "1 TB",
                Color = "silver"
            }
        };

        var createdObject = new TechController(new CustomRestClient()).AddObject<TechItemCreatedAtResponseModel>(objectCreateRequest).Tech;

        var returnedObject = new TechController(new CustomRestClient()).GetObject<TechItemSingleResponseModel>(createdObject.id).Tech;

        var putObject = new TechController(new CustomRestClient()).PutObject<TechItemPutUpdateResponseModel>(put, createdObject.id).Tech;

        var deleteObject = new TechController(new CustomRestClient()).DeleteObject<TechItemDeletedResponseModel>(createdObject.id).Tech;

        var deletedObject = new TechController(new CustomRestClient()).GetObject<TechItemSingleResponseModel>(createdObject.id).Tech;

        Assert.That(putObject.Data.Price, Is.EqualTo(price), "the object is not deleted");
        Assert.That(deletedObject.id, Is.Null, "the object is not deleted");
    }
}