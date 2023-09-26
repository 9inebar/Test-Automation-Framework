using System.Collections.ObjectModel;
using System.Drawing;
using Epam.TestAutomation.Core.Browser;
using OpenQA.Selenium;
using Logger = Epam.TestAutomation.Core.Utils.Logger;

namespace Epam.TestAutomation.Core.Elements;

public abstract class BaseElement : IBaseElement
{
    private readonly IWebElement element;
    protected BaseElement(IWebElement element)
    {
        this.element = element;
    }
    
    protected BaseElement(By locator)
    {
        element = BrowserFactory.Browser.FindElement(locator);
    }

    public IWebElement OriginalWebElement => element;
    
    public string GetText() => OriginalWebElement.Text.Trim();
    
    public string GetAttribute(string attributeName) => OriginalWebElement.GetAttribute(attributeName);
    
    public virtual void Click()
    {
        Logger.Info("Click to element");
        OriginalWebElement.Click();
    }
    
    public void SendKeys(string text)
    {
        Logger.Info("Enter text");
        OriginalWebElement.SendKeys(text);
    }

    public void Clear()
    {
        Logger.Info("Clear the form");
        OriginalWebElement.Clear();
    }

    public bool Exists()
    {
        Logger.Info("Check if exists");
        return OriginalWebElement != null;
    }

    public bool IsDisplayed() => OriginalWebElement.Displayed;
    
    public bool IsEnabled() => OriginalWebElement.Enabled;
    
    public int GetWidth() => OriginalWebElement.Size.Width;
    
    public int GetHeight() => OriginalWebElement.Size.Height;
    
    public Point GetLocation() => OriginalWebElement.Location;
    
    public IWebElement FindElement(By by) => OriginalWebElement.FindElement(by);
    
    public ReadOnlyCollection<IWebElement> FindElements(By by) => OriginalWebElement.FindElements(by);
}