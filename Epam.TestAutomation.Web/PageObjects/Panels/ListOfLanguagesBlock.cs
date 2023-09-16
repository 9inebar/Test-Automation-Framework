using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Panels;

public class ListOfLanguagesBlock : BasePanel
{
   public  ListOfLanguagesBlock(By locator) : base(locator) {} 

    public IWebElement dropDownButton =
        BrowserFactory.Browser.FindElement(By.XPath("//button[@class='location-selector__button']"));

    public IWebElement dropDownMenu =
        BrowserFactory.Browser.FindElement(By.XPath("//nav[@class='location-selector__panel']"));
}