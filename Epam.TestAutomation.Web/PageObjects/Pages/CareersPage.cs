using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Browser;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class CareersPage : BasePage
{
    public override string Url => "https://www.epam.com/";
    
    public By careersButton = By.XPath("//a[@ href='/careers']//parent::span");
    public By findYourDreamJobButton = (By.XPath("(//*[name()='use'])[10]"));
    public bool isAmericasDisplayed = BrowserFactory.Browser.FindElement(By.XPath("//a[@data-item='0']")).Displayed;
    public bool isEMEADisplayed = BrowserFactory.Browser.FindElement(By.XPath("//a[@data-item='1']")).Displayed;
    public bool isAPACDisplayed = BrowserFactory.Browser.FindElement(By.XPath("//a[@data-item='2']")).Displayed;
    
    public string jobListingsUrl = "https://www.epam.com/careers/job-listings";
    public By jobListingsButton = By.XPath("//a[@href='/careers/job-listings']//parent::li[contains(@class, 'top')]");
    
    //DDT test data section
    public By keyWord = By.XPath("//input[@id='new_form_job_search-keyword']");
    public By joinOurTeamFindButton = By.XPath("//button[contains(text(),'Find')]");
    public By jobListingsSearchResults = By.XPath("//div[@class='search-result__sorting-menu']");
    public By jobListingsSearchResultCell = By.XPath("//li[@class='search-result__item']");
    public By jobListingsNoSearchResult = By.XPath("//div[@role='alert']");
}