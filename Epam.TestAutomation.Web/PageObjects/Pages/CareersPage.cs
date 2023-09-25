using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Browser;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class CareersPage : BasePage
{
    public override string Url => "https://www.epam.com/";
    public readonly IWebElement JoinOurTeamButton = BrowserFactory.Browser.FindElement(
            By.XPath("//a[@href='/careers/job-listings']//parent::li[contains(@class, 'top')]"));
    public readonly IWebElement FindYourDreamJobButton = BrowserFactory.Browser.FindElement(By.XPath("(//*[name()='use'])[10]"));
    public readonly bool IsAmericasDisplayed = BrowserFactory.Browser.FindElement(By.XPath("//a[@data-item='0']")).Displayed;
    public readonly bool IsEmeaDisplayed = BrowserFactory.Browser.FindElement(By.XPath("//a[@data-item='1']")).Displayed;
    public readonly bool IsApacDisplayed = BrowserFactory.Browser.FindElement(By.XPath("//a[@data-item='2']")).Displayed;

    public const string JobListingsUrl = "https://www.epam.com/careers/job-listings";
}