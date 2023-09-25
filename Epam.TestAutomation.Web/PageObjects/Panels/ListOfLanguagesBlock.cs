using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Panels;

public class ListOfLanguagesBlock : BasePanel
{
   public  ListOfLanguagesBlock(By locator) : base(locator) {} 

    public readonly IWebElement DropDownButton =
        BrowserFactory.Browser.FindElement(By.XPath("//button[@class='location-selector__button']"));

    public readonly IWebElement DropDownMenu =
        BrowserFactory.Browser.FindElement(By.XPath("//nav[@class='location-selector__panel']"));    
    
    public readonly List<IWebElement> DropDownOption =
        BrowserFactory.Browser.FindElements(By.XPath("//li[@class='location-selector__item']")).ToList();
}