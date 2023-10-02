using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Tests;

public class CareersPageTests : BaseTest
{
    private CareersPage careersPage;

    [SetUp]
    public void SetUp()
    {
        careersPage = new CareersPage();
        careersPage.AcceptAllCookies();
    }

    [Test]
    public void CheckThatListOfCountriesContainsAmerEMEAandAPAC()
    {
        BrowserFactory.Browser.ClickElement(careersPage.careersButton);
        BrowserFactory.Browser.ClickElement(careersPage.findYourDreamJobButton);
        
        Assert.True(careersPage.isAmericasDisplayed, "Americas element not displayed");
        Assert.True(careersPage.isEMEADisplayed, "EMEA element not displayed");
        Assert.True(careersPage.isAPACDisplayed, "APAC not displayed");
    }
    
    [Test]
    public void HoverOverCareerMenuTest()
    {
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.careersButton)).Build().Perform();
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsButton)).Click().Build().Perform();
        Assert.That(BrowserFactory.Browser.GetUrl(),Is.EqualTo(careersPage.jobListingsUrl), "the opened page has wrong url");
    }

    /*[Test]
    public void DDTKeyWordPhrases()
    {
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.careersButton)).Build().Perform();
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsButton)).Click().Build().Perform();
        BrowserFactory.Browser.ClickElement(careersPage.keyWord);
        BrowserFactory.Browser.EnterText(careersPage.keyWord, careersPage.DDTKeyWord);
        BrowserFactory.Browser.ClickElement(careersPage.joinOurTeamFindButton);
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsSearchResults)).Build().Perform();
        Thread.Sleep(3000);
        List<IWebElement> listOfSearchResults =
            BrowserFactory.Browser.FindElements(careersPage.jobListingsSearchResultCell).ToList();
        var expectedResult = careersPage.DDTKeyWord.ToLower();
        IEnumerable<string> resultsToLower = listOfSearchResults.Select(result => result.Text.ToLower());
        var Output = string.Join(",", resultsToLower);
        Assert.That(resultsToLower.All(result => result.Contains(expectedResult)),Is.True, $"The search results are NOT related to your keyword phrase : {Output}");
    }*/
}