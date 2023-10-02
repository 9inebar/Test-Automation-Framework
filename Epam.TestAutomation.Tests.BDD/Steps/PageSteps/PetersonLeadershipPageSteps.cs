using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDD.Steps.PageSteps;

[Binding]
public class PetersonLeadershipPageSteps
{
    private LeadershipPage _leadershipPage = new LeadershipPage();
    
    [When(@"I scroll to Peterson element")]
    public void WhenIScrollToPetersonElement()
    {
        BrowserFactory.Browser.ScrollToElements(_leadershipPage.Peterson.OriginalWebElement);
    }

    [Then(@"I assert Peterson displayed")]
    public void ThenIAssertPetersonDisplayed()
    {
        Assert.That(_leadershipPage.Peterson.IsDisplayed, "Peterson is missing");
    }
}