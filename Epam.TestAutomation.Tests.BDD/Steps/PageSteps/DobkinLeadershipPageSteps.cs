using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDD.Steps.PageSteps;

[Binding]
public class DobkinLeadershipPageSteps
{
    private LeadershipPage _leadershipPage = new LeadershipPage();
    
    [When(@"I scroll to Dobkin element")]
    public void WhenIScrollToDobkinElement()
    {
        BrowserFactory.Browser.ScrollToElements(_leadershipPage.Dobkin.OriginalWebElement);
    }

    [Then(@"I assert Dobkin displayed")]
    public void ThenIAssertItsDisplayed()
    {
        Assert.That(_leadershipPage.Dobkin.IsDisplayed, "Dobkin is missing");
    }
}