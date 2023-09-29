using Epam.TestAutomation.Web.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.Tests.BDD.Steps.ComponentSteps;

[Binding]
public class CookieBannerSteps
{
    private MainPage _mainPage = new MainPage();
    
    [Given(@"accept all cookies on Epam site")]
    public void GivenAcceptAllCoookiesOnEpamSite()
    {
        _mainPage.AcceptAllCookies();
    }
}