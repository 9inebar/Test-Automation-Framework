using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace BDD.Steps.PageSteps;

[Binding]
public class LandingPageSteps
{
    private MainPage mainPage = new MainPage();
    
    [Given(@"I navigate to Epam site")]
    public void GivenINavigateToEpamSite()
    {
        BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl);
        Waiters.WaitForPageLoad();
    }

    

    [When(@"enter a ""(.*)""")]
    public void WhenEnterA(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"click Find button")]
    public void WhenClickFindButton()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the ""(.*)"" contains keyword")]
    public void ThenTheContainsKeyword(string p0)
    {
        ScenarioContext.StepIsPending();
    }
}