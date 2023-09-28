using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Elements;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class AboutPage : BasePage
{
    public override string Url => "https://www.epam.com/";
    
    private MainPage MainPage = new MainPage();
    public Button Leadership = new Button(By.XPath("//span[contains(text(),'Leadership')][1]"));
    public Button Dobkin = new Button(By.XPath("//span[contains(text(),'Dobkin')]//ancestor::a"));
    public Button Peterson = new Button(By.XPath("//span[contains(text(),'Peterson')]//ancestor::a"));
}