using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;

namespace Epam.TestAutomation.Tests;

[TestFixture] [Parallelizable(ParallelScope.All)]
public class MainPageTests : BaseTest
{
    private HowWeDoItPage howUrl;
    private ClientWorkPage clientUrl;

    [SetUp]
    public void SetUp()
    {
        howUrl = new HowWeDoItPage();
        clientUrl = new ClientWorkPage();
    }

    [Test]
    public void MainPageIsOpenedTest()
    {
        Assert.That(BrowserFactory.Browser.GetUrl(), Is.EqualTo(MainPage.Url), "Main page is not displayed correctly");
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
        BrowserFactory.Browser.FindElement(MainPage.SearchButton);
        BrowserFactory.Browser.FindElement(MainPage.EmptyBar);
        BrowserFactory.Browser.FindElement(MainPage.MobileLocationSelector);
        BrowserFactory.Browser.FindElement(MainPage.VendorSearch);
        BrowserFactory.Browser.FindElement(MainPage.MenuDropDown);
    }
    
    [Test]
    public void FindContactUsButton()
    {
        BrowserFactory.Browser.FindElement(MainPage.ContactUsButton);
    }
}