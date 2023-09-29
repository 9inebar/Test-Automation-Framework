using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Web.PageObjects.Pages;
using Epam.TestAutomation.Web.PageObjects.Panels;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Tests;

public class MainPageTests : BaseTest
{
    private MainPage mainPage;
    private HowWeDoItPage howUrl;
    private ClientWorkPage clientUrl;
    private LeadershipPage _leadershipPage;
    private HeaderBlock _headerBlock;

    [SetUp]
    public void SetUp()
    {
        mainPage = new MainPage();
        howUrl = new HowWeDoItPage();
        clientUrl = new ClientWorkPage();
        _headerBlock = new HeaderBlock(By.XPath("//div[@class='header__inner']"));
        _leadershipPage = new LeadershipPage();
        mainPage.AcceptAllCookies();
    }

    [Test]
    public void MainPageIsOpenedTest()
    {
        Assert.That(BrowserFactory.Browser.GetUrl(), Is.EqualTo(mainPage.Url), "Main page is not displayed correctly");
    }
    
    [Test]
    public void CheckThatGoBackToPreviousPageWorks()
    {

        BrowserFactory.Browser.GoToUrl(howUrl.Url);
        BrowserFactory.Browser.GoToUrl(clientUrl.Url);
        BrowserFactory.Browser.Refresh();
        BrowserFactory.Browser.Back();
        Assert.That(BrowserFactory.Browser.GetUrl(), Is.EqualTo(howUrl.Url), "Navigation back works incorrectly");
    }
    [Test]
    public void CreateAndFindSimpleLocators()
    {
        BrowserFactory.Browser.FindElement(mainPage.searchButton);
        BrowserFactory.Browser.FindElement(mainPage.emptyBar);
        BrowserFactory.Browser.FindElement(mainPage.mobileLocationSelector);
        BrowserFactory.Browser.FindElement(mainPage.vendorSearch);
        BrowserFactory.Browser.FindElement(mainPage.menuDropDown);
    }
    
    [Test]
    public void FindContactUsButton()
    {
        BrowserFactory.Browser.FindElement(mainPage.contactUsButton);
    }
    
    [Test]
    public void VerifyThatDobkinAndPetersonAreDisplayed()
    {
        _headerBlock.aboutButton.Click();
        _headerBlock.Leadership.Click();
        BrowserFactory.Browser.ScrollToElements(_leadershipPage.Dobkin.OriginalWebElement);
        Assert.That(_leadershipPage.Dobkin.IsDisplayed, "Dobkin is missing");
        BrowserFactory.Browser.ScrollToElements(_leadershipPage.Peterson.OriginalWebElement);
        Assert.That(_leadershipPage.Peterson.IsDisplayed, "Peterson is missing");
    }
}