using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Web.PageObjects.Pages;
using Epam.TestAutomation.Web.PageObjects.Panels;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Tests;

public class LeadershipPageTests : BaseTest
{
    private MainPage mainPage;
    private HeaderBlock _headerBlock;
    private LeadershipPage _leadershipPage;

    [SetUp]
    public void SetUp()
    {
        mainPage = new MainPage();
        _headerBlock = mainPage.HeaderBlock;
        _leadershipPage = new LeadershipPage();
        mainPage.AcceptAllCookies();
    }
    
    [Test]
    public void VerifyThatDobkinAndPetersonAreDisplayed()
    {
        _headerBlock.AboutButton.Click();
        _headerBlock.Leadership.Click();
        BrowserFactory.Browser.ScrollToElements(_leadershipPage.Dobkin.OriginalWebElement);
        Assert.That(_leadershipPage.Dobkin.IsDisplayed, "Dobkin is missing");
        BrowserFactory.Browser.ScrollToElements(_leadershipPage.Peterson.OriginalWebElement);
        Assert.That(_leadershipPage.Peterson.IsDisplayed, "Peterson is missing");
    }
}