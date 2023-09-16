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
        BrowserFactory.Browser.ClickElement(searchPage.searchButton);
        Waiters.WaitForCondition(()=> searchPage.searchForm.Displayed);
        Waiters.WaitForCondition(()=> searchPage.searchForm.Enabled);
        searchPage.searchForm.Click();
        searchPage.searchForm.SendKeys(SearchPage.keyWord);
        searchPage.findButton.Click();

        Assert.That(BrowserFactory.Browser.Url,Is.EqualTo(searchPage.searchUrl), "The url is wrong");
        
        Assert.That(SearchPage.articlesToLower.All(article => article.Contains(searchPage.expectedResult)),Is.True, $"The first 5 articles don't contain entered text : {searchPage.Output}");
    }
    [Test]
    public void CheckThatTitleOfTheOpenedPageEqualsSearchTitle()
    {
        BrowserFactory.Browser.ClickElement(searchPage.searchButton);
        Waiters.WaitForCondition(()=> searchPage.searchForm.Displayed);
        Waiters.WaitForCondition(()=> searchPage.searchForm.Enabled);
        searchPage.searchForm.Click();
        searchPage.searchForm.SendKeys(SearchPage.keyWord2);
        searchPage.findButton.Click();

        Assert.That(BrowserFactory.Browser.Url,Is.EqualTo(searchPage.searchUrl2), "The url is wrong");
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
        
        BrowserFactory.Browser.ClickElement(searchPage.searchButton);
        Waiters.WaitForCondition(() => searchPage.frequentSearchesFirstItem.Displayed);
        Waiters.WaitForCondition(() => searchPage.frequentSearchesFirstItem.Enabled);
        searchPage.frequentSearchesFirstItem.Click();
        searchPage.findButton.Click();
        IJavaScriptExecutor jse = (IJavaScriptExecutor)BrowserFactory.Browser.Driver;
        jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        Waiters.WaitForCondition(() =>BrowserFactory.Browser.FindElements(searchPage.articles).Count.Equals(numberOfArticles));
        int listOfArticlesAfterViewMore = BrowserFactory.Browser.FindElements(searchPage.articles).Count;
        Assert.That(listOfArticlesAfterViewMore,Is.EqualTo(numberOfArticles), "the number of articles should be 20");
    }
}