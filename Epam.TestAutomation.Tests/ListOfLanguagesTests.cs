using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using Epam.TestAutomation.Web.PageObjects.Panels;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Tests;

[TestFixture] [Parallelizable(ParallelScope.All)]
public class ListOfLanguagesTests : BaseTest
{
    private MainPage mainPage;
    private ListOfLanguagesBlock _listOfLanguagesBlock;
    
    [SetUp]
    public void SetUp()
    {
        mainPage = new MainPage();
        _listOfLanguagesBlock = new ListOfLanguagesBlock((By.XPath("//button[@class='location-selector__button']")));
    }
    [Test]
    public void VerifyListOfLangIsCorrect()
    {
        _listOfLanguagesBlock.dropDownButton.Click();
        Waiters.WaitForCondition(() => _listOfLanguagesBlock.dropDownMenu.Displayed);
        List<string> listOfLanguages = new List<string> { "Global (English)", "Česká Republika (Čeština)", "Czech Republic (English)", "DACH (Deutsch)", "Hungary (English)", "India (English)", "日本 (日本語)","Polska (Polski)","СНГ (Русский)", "Україна (Українська)", "中国 (中文)"};
        IEnumerable<string> listOfActualLanguages =
            BrowserFactory.Browser.FindElements(By.XPath("//li[@class='location-selector__item']")).ToList().Select(l => l.GetAttribute("outerText"));
        CollectionAssert.AreEquivalent(listOfLanguages,listOfActualLanguages);
    }
}