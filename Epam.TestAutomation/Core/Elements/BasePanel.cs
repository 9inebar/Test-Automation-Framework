using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements;

public class BasePanel : BaseElement
{
    public BasePanel (By locator) : base(locator)
    {
        
    }

    public BasePanel (IWebElement element) : base(element)
    {
        
    }
}