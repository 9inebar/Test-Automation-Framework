using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Panels;

public class HeaderBlock : BasePanel
{
    public Button SearchButton => new Button(By.XPath("//*[contains(@class, 'header-search__button')]"));

    public SearchBlock SearchBlock => new SearchBlock(By.XPath("//*[contains(@class, 'header-search__panel')]"));

    public Button aboutButton = new Button(By.XPath("//a[@ href='/about']//parent::span")); 

    public HeaderBlock(By locator) : base(locator) { }
}