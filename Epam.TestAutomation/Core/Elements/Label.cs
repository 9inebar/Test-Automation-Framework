using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements;

public class Label : BaseElement
{
    public Label(By locator) : base(locator)
    {
        
    }

    public Label(WebElement element) : base(element)
    {
        
    }
}