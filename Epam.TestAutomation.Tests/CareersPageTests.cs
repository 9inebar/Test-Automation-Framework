using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Tests.DDT.Models;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CareersPageTests : BaseTest
{
    private CareersPage careersPage;

    [SetUp]
    public void SetUp()
    {
        careersPage = new CareersPage();
        careersPage.AcceptAllCookies();
    }

    [Test]
    public void CheckThatListOfCountriesContainsAmerEMEAandAPAC()
    {
        BrowserFactory.Browser.ClickElement(careersPage.careersButton);
        BrowserFactory.Browser.ClickElement(careersPage.findYourDreamJobButton);
        
        Assert.True(careersPage.isAmericasDisplayed, "Americas element not displayed");
        Assert.True(careersPage.isEMEADisplayed, "EMEA element not displayed");
        Assert.True(careersPage.isAPACDisplayed, "APAC not displayed");
    }
    
    [Test]
    public void HoverOverCareerMenuTest()
    {
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.careersButton)).Build().Perform();
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsButton)).Click().Build().Perform();
        Assert.That(BrowserFactory.Browser.GetUrl(),Is.EqualTo(careersPage.jobListingsUrl), "the opened page has wrong url");
    }

    [Test]
    [TestCaseSource(nameof(GetSearchTestData1))]
    public void DDTKeyWordPhrases(SearchModel searchModel)
    {
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.careersButton)).Build().Perform();
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsButton)).Click().Build().Perform();
        BrowserFactory.Browser.ClickElement(careersPage.keyWord);
        BrowserFactory.Browser.EnterText(careersPage.keyWord, searchModel.SearchPhrase);
        BrowserFactory.Browser.ClickElement(careersPage.joinOurTeamFindButton);
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsSearchResults)).Build().Perform();
        Thread.Sleep(3000);
        List<IWebElement> listOfSearchResults = BrowserFactory.Browser.FindElements(careersPage.jobListingsSearchResultCell).ToList();
        var expectedResult = searchModel.SearchResult.ToLower();
        List<string> resultsToLower = listOfSearchResults.Select(result => result.Text.ToLower()).ToList();
        var Output = string.Join(",", resultsToLower);
        Assert.That(resultsToLower.All(result => result.Contains(expectedResult)),Is.True, $"The search results are NOT related to your keyword phrase : {Output}");
    }
    static List<SearchModel> GetSearchTestData1()
    {
        var json = File.ReadAllText("/Users/alehhramovich/RiderProjects/Epam.TestAutomation/Epam.TestAutomation.Tests.DDT/TestData/DDTKeyWordPhrases.json");
        return JsonParser.DeserializeJsonToObjects<SearchModel>(json);
    }
    
    [Test]
    [TestCaseSource(nameof(GetSearchTestData2))]
    public void DDTSelectedLocations(SelectModel selectModel)
    {
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.careersButton)).Build().Perform();
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsButton)).Click().Build().Perform();
        BrowserFactory.Browser.ClickElement(By.XPath("//span[@class='select2-selection__rendered']"));
        BrowserFactory.Browser.ClickElement(By.XPath("//strong[contains(text(),'Belgium')]"));
        BrowserFactory.Browser.ClickElement(By.XPath($"//strong[contains(text(),'{SelectModel.SearchCountry}')]"));
        BrowserFactory.Browser.ClickElement(By.XPath($"//li[contains(text(),'{SelectModel.SearchCity}')]"));
        BrowserFactory.Browser.ClickElement(careersPage.joinOurTeamFindButton);
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsSearchResults)).Build().Perform();
        Thread.Sleep(3000);
        List<IWebElement> listOfSearchResults = BrowserFactory.Browser.FindElements(careersPage.jobListingsSearchResultCell).ToList();
        var expectedResult = SelectModel.SearchResult.ToLower();
        List<string> resultsToLower = listOfSearchResults.Select(result => result.Text.ToLower()).ToList();
        var Output = string.Join(",", resultsToLower);
        Assert.That(resultsToLower.All(result => result.Contains(expectedResult)),Is.True, $"The search results are NOT related to your keyword phrase : {Output}");
    }
    static List<SelectModel> GetSearchTestData2()
    {
        var json = File.ReadAllText("/Users/alehhramovich/RiderProjects/Epam.TestAutomation/Epam.TestAutomation.Tests.DDT/TestData/DDTSelectedLocations.json");
        return JsonParser.DeserializeJsonToObjects<SelectModel>(json);
    }
    
    [Test]
    [TestCaseSource(nameof(GetSearchTestData3))]
    public void DDTSelectedSkills(SelectSkillsModel searchSkillsModel)
    {
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.careersButton)).Build().Perform();
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsButton)).Click().Build().Perform();
        BrowserFactory.Browser.ClickElement(By.XPath("//div[@class='selected-params ']"));
        Thread.Sleep(3000);
        BrowserFactory.Browser.ClickElement(By.XPath($"//span[contains(text(),'{SelectSkillsModel.SearchSkill}')]"));
        BrowserFactory.Browser.ClickElement(careersPage.joinOurTeamFindButton);
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsSearchResults)).Build().Perform();
        Thread.Sleep(3000);
        List<IWebElement> listOfSearchResults = BrowserFactory.Browser.FindElements(careersPage.jobListingsSearchResultCell).ToList();
        List<string> resultsToLower = listOfSearchResults.Select(result => result.Text.ToLower()).ToList();
        var expectedResult = SelectSkillsModel.SearchResult;
        var Output = string.Join(",", resultsToLower);
        Assert.That(resultsToLower.All(result => result.Contains(expectedResult)),Is.True, $"The search results are NOT related to your keyword phrase : {Output}");
    }
    static List<SelectSkillsModel> GetSearchTestData3()
    {
        var json = File.ReadAllText("/Users/alehhramovich/RiderProjects/Epam.TestAutomation/Epam.TestAutomation.Tests.DDT/TestData/DDTSelectedSkills.json");
        return JsonParser.DeserializeJsonToObjects<SelectSkillsModel>(json);
    }
    
    [Test]
    [TestCaseSource(nameof(GetSearchTestData4))]
    public void DDTSelectedSkillsAndLocations(SkillsAndLocationsModel skillsAndLocationsModel)
    {
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.careersButton)).Build().Perform();
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsButton)).Click().Build().Perform();
        BrowserFactory.Browser.ClickElement(careersPage.keyWord);
        BrowserFactory.Browser.EnterText(careersPage.keyWord, SkillsAndLocationsModel.SearchPhrase);
        BrowserFactory.Browser.ClickElement(By.XPath("//span[@class='select2-selection__rendered']"));
        BrowserFactory.Browser.ClickElement(By.XPath($"//strong[contains(text(),'{SkillsAndLocationsModel.SearchCountry}')]"));
        BrowserFactory.Browser.ClickElement(By.XPath($"//li[contains(text(),'{SkillsAndLocationsModel.SearchCity}')]"));
        BrowserFactory.Browser.ClickElement(By.XPath("//div[@class='selected-params ']"));
        Thread.Sleep(3000);
        BrowserFactory.Browser.ClickElement(By.XPath($"//span[contains(text(),'{SkillsAndLocationsModel.SearchSkill}')]"));
        BrowserFactory.Browser.ClickElement(careersPage.joinOurTeamFindButton);
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsSearchResults)).Build().Perform();
        Thread.Sleep(3000);
        List<IWebElement> listOfSearchResults = BrowserFactory.Browser.FindElements(careersPage.jobListingsSearchResultCell).ToList();
        List<string> resultsToLower = listOfSearchResults.Select(result => result.Text.ToLower()).ToList();
        var expectedResult = SkillsAndLocationsModel.SearchResult;
        var Output = string.Join(",", resultsToLower);
        Assert.That(resultsToLower.All(result => result.Contains(expectedResult)),Is.True, $"The search results are NOT related to your keyword phrase : {Output}");
        
    }
    static List<SkillsAndLocationsModel> GetSearchTestData4()
    {
        var json = File.ReadAllText("/Users/alehhramovich/RiderProjects/Epam.TestAutomation/Epam.TestAutomation.Tests.DDT/TestData/DDTSelectedSkills.json");
        return JsonParser.DeserializeJsonToObjects<SkillsAndLocationsModel>(json);
    }
    
    [Test]
    [TestCaseSource(nameof(GetSearchTestData5))]
    public void DDTSelectedSkillsAndKeyWords(KeyWordAndLocationModel keyWordAndLocationModel)
    {
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.careersButton)).Build().Perform();
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsButton)).Click().Build().Perform();
        BrowserFactory.Browser.ClickElement(careersPage.keyWord);
        BrowserFactory.Browser.EnterText(careersPage.keyWord, KeyWordAndLocationModel.SearchPhrase);
        BrowserFactory.Browser.ClickElement(By.XPath("//span[@class='select2-selection__rendered']"));
        BrowserFactory.Browser.ClickElement(By.XPath($"//strong[contains(text(),'{KeyWordAndLocationModel.SearchCountry}')]"));
        BrowserFactory.Browser.ClickElement(By.XPath($"//li[contains(text(),'{KeyWordAndLocationModel.SearchCity}')]"));
        BrowserFactory.Browser.ClickElement(careersPage.joinOurTeamFindButton);
        action.MoveToElement(BrowserFactory.Browser.FindElement(careersPage.jobListingsNoSearchResult)).Build().Perform();
        Thread.Sleep(3000);
        List<IWebElement> listOfSearchResults = BrowserFactory.Browser.FindElements(careersPage.jobListingsSearchResultCell).ToList();
        List<string> resultsToLower = listOfSearchResults.Select(result => result.Text.ToLower()).ToList();
        var expectedResult = KeyWordAndLocationModel.SearchResult;
        var Output = string.Join(",", resultsToLower);
        Assert.That(resultsToLower.All(result => result.Contains(expectedResult)),Is.True, $"The search results are NOT related to your keyword phrase : {Output}");
    }
    private static List<KeyWordAndLocationModel> GetSearchTestData5()
    {
        var json = File.ReadAllText("/Users/alehhramovich/RiderProjects/Epam.TestAutomation/Epam.TestAutomation.Tests.DDT/TestData/DDTSelectedSkillsAndKeyWords.json");
        return JsonParser.DeserializeJsonToObjects<KeyWordAndLocationModel>(json);
    }
}