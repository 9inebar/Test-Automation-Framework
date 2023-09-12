using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements;

public class Dropdown : BaseElement
{
    public Dropdown (By locator) : base(locator)
    {
        
    }

    public Dropdown(IWebElement element) : base(element)
    {
        
    }
}