using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;

namespace Epam.TestAutomation.Tests;
[TestFixture] [Parallelizable(ParallelScope.All)]
public class MainPageTests : BaseTest
{
    private MainPage mainPage;
    private HowWeDoItPage howUrl;
    private ClientWorkPage clientUrl;

    [SetUp]
    public void SetUp()
    {
        mainPage = new MainPage();
        howUrl = new HowWeDoItPage();
        clientUrl = new ClientWorkPage();
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
}