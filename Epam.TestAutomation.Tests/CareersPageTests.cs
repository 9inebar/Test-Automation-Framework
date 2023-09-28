using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Tests;

public class CareersPageTests : BaseTest
{
    private CareersPage _careersPage;

    [SetUp]
    public void SetUp()
    {
        _careersPage = new CareersPage();
        _careersPage.AcceptAllCookies();
    }

    [Test]
    public void CheckThatListOfCountriesContainsAmerEmeAandApac()
    {
        _careersPage.careersButton.Click();
        _careersPage.findYourDreamJobButton.Click();
        
        Assert.True(_careersPage.isAmericasDisplayed, "Americas element not displayed");
        Assert.True(_careersPage.isEMEADisplayed, "EMEA element not displayed");
        Assert.True(_careersPage.isAPACDisplayed, "APAC not displayed");
    }
    
    [Test]
    public void HoverOverCareerMenuTest()
    {
        BrowserFactory.Browser.Action.MoveToElement(_careersPage.careersButton).Build().Perform();
        BrowserFactory.Browser.Action.MoveToElement(_careersPage.jobListingsButton).Click().Build().Perform();
        Assert.That(BrowserFactory.Browser.GetUrl(),Is.EqualTo(_careersPage.jobListingsUrl), "the opened page has wrong url");
    }

    [Test]
    public void DdtKeyWordPhrases()
    {
        BrowserFactory.Browser.Action.MoveToElement(_careersPage.careersButton).Build().Perform();
        BrowserFactory.Browser.Action.MoveToElement(_careersPage.jobListingsButton).Click().Build().Perform();
        BrowserFactory.Browser.ClickElement(_careersPage.keyWord);
        BrowserFactory.Browser.EnterText(_careersPage.keyWord, _careersPage.DDTKeyWord);
        BrowserFactory.Browser.ClickElement(_careersPage.joinOurTeamFindButton);
        BrowserFactory.Browser.Action.MoveToElement(_careersPage.jobListingsSearchResults).Build().Perform();
        Thread.Sleep(3000);
        List<IWebElement> listOfSearchResults =
            BrowserFactory.Browser.FindElements(_careersPage.jobListingsSearchResultCell).ToList();
        var expectedResult = _careersPage.DDTKeyWord.ToLower();
        IEnumerable<string> resultsToLower = listOfSearchResults.Select(result => result.Text.ToLower());
        var output = string.Join(",", resultsToLower);
        Assert.That(resultsToLower.All(result => result.Contains(expectedResult)),Is.True, $"The search results are NOT related to your keyword phrase : {output}");
    }
}