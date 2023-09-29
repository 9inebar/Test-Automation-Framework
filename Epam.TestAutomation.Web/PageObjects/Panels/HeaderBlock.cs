using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Panels;

public class HeaderBlock : BasePanel
{
    public IWebElement aboutButton => BrowserFactory.Browser.FindElement(By.XPath("//a[@ href='/about']//parent::span")); 
    //public IWebElement Leadership = BrowserFactory.Browser.FindElement(By.XPath("//*[contains (@class, 'sub')]/*[contains (@href, 'are/leadership')]"));
    public HtmlElement Leadership => new HtmlElement(By.XPath("//a[@href='https://www.epam.com/about/who-we-are/leadership' and descendant::span[contains(text(), 'Leadership')]]"));

    public Button SearchButton => new Button(By.XPath("//*[contains(@class, 'header-search__button')]"));

    public SearchBlock SearchBlock => new SearchBlock(By.XPath("//*[contains(@class, 'header-search__panel')]"));

    public HeaderBlock(By locator) : base(locator) { }
}