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
        CollectionAssert.IsNotEmpty(response.Objects,
            "Any object should be returned when sending GET request to /objects");
    }

    [Test]
    public void CreateTechItemWithCapacityGBTest()
    {
        var capacity = 1024;


        var techItem = new TechItemRequestModel()
        {
            name = "Apple MacBook Pro 16",
            data = new TechData
            {
                Price = 2089,
                CapacityGB = 2048
            }
        };

        var createdItem = new TechController(new CustomRestClient())
            .AddTechItem<TechItemCreatedAtResponseModel>(techItem).Tech;

        var receivedItem = new TechController(new CustomRestClient())
            .GetSingleTechItem<TechItemSingleResponseModel>(createdItem.id).Tech;

        var deleteAnItem = new TechController(new CustomRestClient())
            .DeleteCreatedItem<TechItemDeletedResponseModel>(createdItem.id).Tech;

        Assert.That(receivedItem.data.CapacityGB, Is.EqualTo(capacity), "Object fields don't match");
        Assert.That(deleteAnItem.DeletionMessage.Contains(createdItem.id), "the object is not deleted");
    }

    [Test]
    public void DeleteCreatedTechItemTest()
    {

        var techItem = new TechItemRequestModel()
        {
            name = "Apple iPhone 14 Pro",
            data = new TechData
            {
                Price = 1300,
                Generation = "14"
            }
        };

        var createdItem = new TechController(new CustomRestClient())
            .AddTechItem<TechItemCreatedAtResponseModel>(techItem).Tech;

        var receivedItem = new TechController(new CustomRestClient())
            .GetSingleTechItem<TechItemSingleResponseModel>(createdItem.id).Tech;

        var deleteAnItem = new TechController(new CustomRestClient())
            .DeleteCreatedItem<TechItemDeletedResponseModel>(createdItem.id).Tech;

        var deletedItem = new TechController(new CustomRestClient())
            .GetSingleTechItem<TechItemSingleResponseModel>(createdItem.id).Tech;

        Assert.That(deletedItem.id, Is.Null, "Item is not deleted");
    }
    
    [Test]
    public void PathCreatedTechItemTest()
    {
        var newPrice = 2000;

        var techItem = new TechItemRequestModel()
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

        var createdItem = new TechController(new CustomRestClient()).AddTechItem<TechItemCreatedAtResponseModel>(techItem).Tech;

        var receivedItem = new TechController(new CustomRestClient()).GetSingleTechItem<TechItemSingleResponseModel>(createdItem.id).Tech;

        var patchedItem = new TechController(new CustomRestClient()).PatchTechItem<TechItemPatchUpdateResponseModel>(patch, createdItem.id).Tech;

        var deleteAnItem = new TechController(new CustomRestClient()).DeleteCreatedItem<TechItemDeletedResponseModel>(createdItem.id).Tech;

        Assert.That(patchedItem.Data.Price, Is.EqualTo(newPrice), "Updated value should match");
        Assert.That(deleteAnItem.DeletionMessage.Contains(createdItem.id), "the object is not deleted");
    }
}