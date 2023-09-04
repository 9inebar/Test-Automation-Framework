using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Tests;
[TestFixture]
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
        BrowserFactory.Browser.GoToUrl(careersPage.jobListingsUrl);
        Waiters.WaitForPageLoad();
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.careersButton)).Build().Perform();
        Thread.Sleep(3000);
        action.MoveToElement(BrowserFactory.Browser.FindElement(By.XPath("//a[@href='/careers/job-listings']//parent::li[contains(@class, 'top')]"))).Click().Build().Perform();
        Assert.That(BrowserFactory.Browser.GetUrl(),Is.EqualTo(careersPage.jobListingsUrl), "the opened page has wrong url");
    }
}