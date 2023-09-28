using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Browser;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class AboutPage : BasePage
{
    public override string Url => "https://www.epam.com/about/who-we-are/leadership";
    
    public IWebElement Dobkin = BrowserFactory.Browser.FindElement(By.XPath("//span[contains(text(),'Dobkin')]//ancestor::a"));
    public IWebElement Peterson = BrowserFactory.Browser.FindElement(By.XPath("//span[contains(text(),'Peterson')]//ancestor::a"));
}