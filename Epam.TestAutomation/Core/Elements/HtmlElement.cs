using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements;

public class HtmlElement : BaseElement
{
    public HtmlElement(By locator) : base(locator)
    {

    }

    public HtmlElement(IWebElement element) : base(element)
    {

    }
}