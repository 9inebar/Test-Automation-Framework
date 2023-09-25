using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Tests;
[TestFixture] [Parallelizable(ParallelScope.All)]
public class SearchPageTests : BaseTest
{
    private SearchPage searchPage;
    
    [SetUp]
    public void SetUp()
    {
        searchPage = new SearchPage();
    }
    
    [Test]
    public void CheckThatUrlToSearchContainsMyText()
    {
        BrowserFactory.Browser.ClickElement(MainPage.SearchButton);
        Waiters.WaitForCondition(()=> MainPage.SearchForm.Displayed);
        Waiters.WaitForCondition(()=> MainPage.SearchForm.Enabled);
        MainPage.SearchForm.Click();
        MainPage.SearchForm.SendKeys(searchPage.KeyWord);
        MainPage.FindButton.Click();

        Assert.That(BrowserFactory.Browser.Url,Is.EqualTo(searchPage.SearchUrl), "The url is wrong");
        var articlesToLower = searchPage.ListOfArticles.Select(article => article.Text.ToLower());
        var output = string.Join(",", articlesToLower);
        var expectedResult = searchPage.KeyWord.ToLower();
        Assert.That(articlesToLower.All(article => article.Contains(expectedResult)),Is.True, $"The first 5 articles don't contain entered text : {output}");
    }
    [Test]
    public void CheckThatTitleOfTheOpenedPageEqualsSearchTitle()
    {
        BrowserFactory.Browser.ClickElement(MainPage.SearchButton);
        Waiters.WaitForCondition(()=> MainPage.SearchForm.Displayed);
        Waiters.WaitForCondition(()=> MainPage.SearchForm.Enabled);
        MainPage.SearchForm.Click();
        MainPage.SearchForm.SendKeys(SearchPage.KeyWord2);
        MainPage.FindButton.Click();

        Assert.That(BrowserFactory.Browser.Url,Is.EqualTo(searchPage.SearchUrl2), "The url is wrong");
        string firstArticleTitle = BrowserFactory.Browser.FindElement(By.XPath("//a[@class='search-results__title-link'][1]")).Text;
        By searchResults = By.XPath("//a[@class='search-results__title-link']");
        BrowserFactory.Browser.ClickElement(searchResults);
        string openedArticleTitle = BrowserFactory.Browser.FindElement(By.XPath("(//span[@class='museo-sans-light'])[last()]")).Text;
        Assert.That(firstArticleTitle, Is.EqualTo(openedArticleTitle), "Titles are different");
    }

    [Test]
    public void WriteXPathLocators()
    {
        BrowserFactory.Browser.FindElement(By.XPath("//*[contains (@class, 'cookie')]//child::*[@class='iparys_inherited']"));
        BrowserFactory.Browser.FindElement(By.XPath("//div[@id='wrapper']//following-sibling::*[@class='header-container iparsys parsys']"));
        BrowserFactory.Browser.FindElement(By.XPath("//div[@class='header-search__panel']//parent::h3"));
        BrowserFactory.Browser.FindElement(By.XPath("//button[@class='location-selector__button']"));
        BrowserFactory.Browser.FindElement(By.XPath("//a[@ href='/careers']//parent::span"));
    }
    [Test]
    public void CheckThatThereAre20Elements()
    {
        int numberOfArticles = 20;
        
        BrowserFactory.Browser.ClickElement(MainPage.SearchButton);
        Waiters.WaitForCondition(() => MainPage.FrequentSearchesFirstItem.Displayed);
        Waiters.WaitForCondition(() => MainPage.FrequentSearchesFirstItem.Enabled);
        MainPage.FrequentSearchesFirstItem.Click();
        MainPage.FindButton.Click();
        IJavaScriptExecutor jse = (IJavaScriptExecutor)BrowserFactory.Browser.Driver;
        jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        Waiters.WaitForCondition(() =>BrowserFactory.Browser.FindElements(searchPage.Articles).Count.Equals(numberOfArticles));
        int listOfArticlesAfterViewMore = BrowserFactory.Browser.FindElements(searchPage.Articles).Count;
        Assert.That(listOfArticlesAfterViewMore,Is.EqualTo(numberOfArticles), "the number of articles should be 20");
    }
}