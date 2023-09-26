using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements;

public class Checkbox : BaseElement
{
    public Checkbox(By locator) : base(locator)
    {
        
    }

    public Checkbox(IWebElement element) : base(element)
    {
        
    }
}