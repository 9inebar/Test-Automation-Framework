using System.Net;
using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.Models.ResponseModels;
using NUnit.Framework;
using RestSharp;

namespace Epam.TestAutomation.API.Tests;

public class TechTests
{
    [Test]
    public void CheckAllObjectsResponseWithValidParams()
    {
        var response = new TechController(new CustomRestClient()).GetObjects<RestResponse>();
        Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "invalid status code was returned when sending GET request to /objects");
    }
    
    [Test]
    public void CheckAllObjectsResponseReturnsObject()
    {
        var response = new TechController(new CustomRestClient()).GetObjects<AllTechModel>();
        CollectionAssert.IsNotEmpty(response.Objects.data, "Any object should be returned when sending GET request to /objects");
    }
}