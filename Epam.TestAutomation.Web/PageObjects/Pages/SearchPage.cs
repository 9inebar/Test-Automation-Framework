using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Browser;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class SearchPage : BasePage
{
    public override string Url => "https://www.epam.com/";

    //first test variables
    public readonly string KeyWord = "Automation";
    public readonly string SearchUrl = "https://www.epam.com/search?q=Automation";
    public IEnumerable<IWebElement>
        ListOfArticles = BrowserFactory.Browser.FindElements(By.XPath("//article")).ToList();

    //second test variables
    public static readonly string KeyWord2 = "Business Analysis";
    public readonly string SearchUrl2 = "https://www.epam.com/search?q=Business+Analysis";
    //fourth test variables
    
    public readonly By Articles = By.XPath("//article");
}