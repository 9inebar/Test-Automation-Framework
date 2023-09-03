using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Browser;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class SearchPage : BasePage
{
    public override string Url => "https://www.epam.com/";

    //first test variables
    public static string keyWord = "Automation";
    public string searchUrl = "https://www.epam.com/search?q=Automation";
    public By searchButton = By.XPath("//span[@class='search-icon dark-iconheader-search__search-icon']");
    public By searchForm = (By.XPath("//input[@id='new_form_search']"));
    public By findButton = (By.XPath("//span[@class='bth-text-layer']"));

    public static IEnumerable<IWebElement> listOfArticles =
        BrowserFactory.Browser.FindElements(By.XPath("//article")).ToList().Take(5);

    public static IEnumerable<string> articlesToLower = listOfArticles.Select(article => article.Text.ToLower());
    public string expectedResult = keyWord.ToLower();

    public string Output = string.Join(",", articlesToLower);

    //second test variables
    public static string keyWord2 = "Business Analysis";
    public string searchUrl2 = "https://www.epam.com/search?q=Business+Analysis";
    //fourth test variables
    public By frequentSearchesFirstItem = By.XPath("//li[@class='frequent-searches__item'][1]");
    public By articles = (By.XPath("//article"));
}