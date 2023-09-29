using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class AboutPage : BasePage
{
    public override string Url => "https://www.epam.com/about/who-we-are/leadership";
    
    public HtmlElement Dobkin => new HtmlElement(By.XPath("//a[@href=\"/about/who-we-are/leadership/executive-management/arkadiy-dobkin\" and descendant::img[contains(@src, 'Dobkin')]]"));
    public HtmlElement Peterson => new HtmlElement(By.XPath("//a[@href=\"/about/who-we-are/leadership/executive-management/jason-peterson\" and descendant::img[contains(@src, 'Peterson')]]"));
}