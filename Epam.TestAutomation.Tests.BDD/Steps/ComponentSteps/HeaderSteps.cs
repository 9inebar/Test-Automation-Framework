using Epam.TestAutomation.Web.PageObjects.Pages;
using Epam.TestAutomation.Web.PageObjects.Panels;
using TechTalk.SpecFlow;

namespace BDD.Steps.ComponentSteps;

[Binding]
public class HeaderSteps
{
    private HeaderBlock _headerBlock = new MainPage().HeaderBlock;
    
    [When(@"click About element")]
    public void WhenClickAboutElement()
    {
        _headerBlock.AboutButton.Click();
    }
    
    [When(@"click Leadership element")]
    public void WhenClickLeadershipElement()
    {
        _headerBlock.Leadership.Click();
    }
}   