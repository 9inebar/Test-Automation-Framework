using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;

namespace Epam.TestAutomation.Tests;
[TestFixture] [Parallelizable(ParallelScope.All)]
public class CareersPageTests : BaseTest
{
    private CareersPage careersPage;

    [SetUp]
    public void SetUp()
    {
        careersPage = new CareersPage();
    }

    [Test]
    public void CheckThatListOfCountriesContainsAmerEMEAandAPAC()
    {
        careersPage.careersButton.Click();
        careersPage.findYourDreamJobButton.Click();
        
        Assert.True(careersPage.isAmericasDisplayed, "Americas element not displayed");
        Assert.True(careersPage.isEMEADisplayed, "EMEA element not displayed");
        Assert.True(careersPage.isAPACDisplayed, "APAC not displayed");
    }
    
    [Test]
    public void HoverOverCareerMenuTest()
    {
        BrowserFactory.Browser.Action.MoveToElement(careersPage.careersButton).Build().Perform();
        Waiters.WaitForCondition(()=>careersPage.joinOurTeamButton.Displayed);
        BrowserFactory.Browser.Action.MoveToElement(careersPage.joinOurTeamButton).Click().Build().Perform();
        Assert.That(BrowserFactory.Browser.GetUrl(),Is.EqualTo(careersPage.jobListingsUrl), "the opened page has wrong url");
    }
}