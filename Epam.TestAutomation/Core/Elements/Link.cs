using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements;

public class Link : BaseElement
{
    public Link(By locator) : base(locator)
    {

    }

    public Link(IWebElement element) : base(element)
    {

    }
}