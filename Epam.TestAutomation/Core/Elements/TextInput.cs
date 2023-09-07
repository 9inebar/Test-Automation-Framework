using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements;

public class TextInput : BaseElement
{
    public TextInput(By locator) : base(locator)
    {
        
    }

    public TextInput(IWebElement element) : base(element)
    {
        
    }
}