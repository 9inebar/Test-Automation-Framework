namespace Epam.TestAutomation.Core.Elements;

public interface IBaseElement
{
    string GetText();
    string GetAttribute(string attributeName);
    void Click();
    void SendKeys(string text);
    void Clear();
    bool Exists();
    bool IsDisplayed();
    bool IsEnabled();
}