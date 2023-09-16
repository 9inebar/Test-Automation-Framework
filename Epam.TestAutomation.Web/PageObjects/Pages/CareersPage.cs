using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Browser;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class CareersPage : BasePage
{
    public override string Url => "https://www.epam.com/";
    
    public IWebElement careersButton = BrowserFactory.Browser.FindElement(By.XPath("//a[@ href='/careers']//parent::span"));

    public IWebElement joinOurTeamButton =
        BrowserFactory.Browser.FindElement(
            By.XPath("//a[@href='/careers/job-listings']//parent::li[contains(@class, 'top')]"));
    public IWebElement findYourDreamJobButton = BrowserFactory.Browser.FindElement(By.XPath("(//*[name()='use'])[10]"));
    public bool isAmericasDisplayed = BrowserFactory.Browser.FindElement(By.XPath("//a[@data-item='0']")).Displayed;
    public bool isEMEADisplayed = BrowserFactory.Browser.FindElement(By.XPath("//a[@data-item='1']")).Displayed;
    public bool isAPACDisplayed = BrowserFactory.Browser.FindElement(By.XPath("//a[@data-item='2']")).Displayed;
    
    public string jobListingsUrl = "https://www.epam.com/careers/job-listings";
}