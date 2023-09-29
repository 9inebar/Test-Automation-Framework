using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Panels;

public class HeaderBlock : BasePanel
{
    public HtmlElement AboutButton => new HtmlElement(By.XPath("//a[@ href='/about']//parent::span")); 
    public HtmlElement Leadership => new HtmlElement(By.XPath("//a[@href='https://www.epam.com/about/who-we-are/leadership' and descendant::span[contains(text(), 'Leadership')]]"));

    public HeaderBlock(By locator) : base(locator)
    {
        
    }
}