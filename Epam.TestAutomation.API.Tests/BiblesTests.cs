using System.Net;
using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.Models.ResponseModels;
using NUnit.Framework;
using RestSharp;

namespace Epam.TestAutomation.API.Tests;

[TestFixture]
public class BiblesTests
{
    [Test]
    public void CheckAllBiblesResponseWithValidParams()
    {
        var response = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
        Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "invalid status code was returned when sending GET request to /v1/bibles");
    }
    
    [Test]
    public void CheckAllBiblesResponseWithoutAuthorisation()
    {
        var response = new BiblesController(new CustomRestClient(), string.Empty).GetBibles<AllBiblesModel>();
        Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "invalid status code was returned when sending GET request to /v1/bibles without authorisation");
    }
    
    [Test]
    public void CheckAllBiblesResponseReturnsObject()
    {
        var response = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>();
        CollectionAssert.IsNotEmpty(response.Bibles.data, "Any bible should be returned when sending GET request to /v1/bibles without authorisation");
    }
}