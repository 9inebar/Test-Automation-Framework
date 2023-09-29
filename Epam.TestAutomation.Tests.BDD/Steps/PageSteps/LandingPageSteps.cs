using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.Tests.BDD.Steps.PageSteps;

[Binding]
public class LandingPageSteps
{
    private MainPage _mainPage = new MainPage();
    
    [Given(@"I Navigate to landing page of Epam site")]
    public void GivenINavigateToLandingPageOfEpamSite()
    {
        BrowserFactory.Browser.GoToUrl(_mainPage.Url);
        Waiters.WaitForPageLoad();
    }
}