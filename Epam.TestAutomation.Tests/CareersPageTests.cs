using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;

namespace Epam.TestAutomation.Tests;
[TestFixture] [Parallelizable(ParallelScope.All)]
public class CareersPageTests : BaseTest
{
    private CareersPage _careersPage;

    [SetUp]
    public void SetUp()
    {
        _careersPage = new CareersPage();
    }

    [Test]
    public void CheckThatListOfCountriesContainsAmerEmeAandApac()
    {
        MainPage.CareersButton.Click();
        _careersPage.FindYourDreamJobButton.Click();
        
        Assert.True(_careersPage.IsAmericasDisplayed, "Americas element not displayed");
        Assert.True(_careersPage.IsEmeaDisplayed, "EMEA element not displayed");
        Assert.True(_careersPage.IsApacDisplayed, "APAC not displayed");
    }
    
    [Test]
    public void HoverOverCareerMenuTest()
    {
        BrowserFactory.Browser.Action.MoveToElement(MainPage.CareersButton).Build().Perform();
        Waiters.WaitForCondition(()=>_careersPage.JoinOurTeamButton.Displayed);
        BrowserFactory.Browser.Action.MoveToElement(_careersPage.JoinOurTeamButton).Click().Build().Perform();
        Assert.That(BrowserFactory.Browser.GetUrl(),Is.EqualTo(CareersPage.JobListingsUrl), "the opened page has wrong url");
    }
}