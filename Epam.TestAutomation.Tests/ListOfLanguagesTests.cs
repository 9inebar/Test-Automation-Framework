using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Tests;

public class ListOfLanguagesTests : BaseTest
{
    private ListOfLanguagesPage listOfLanguagesPage;
    
    [SetUp]
    public void SetUp()
    {
        listOfLanguagesPage = new ListOfLanguagesPage();
        listOfLanguagesPage.AcceptAllCookies();
    }
    [Test]
    public void VerifyListOfLangIsCorrect()
    {
        BrowserFactory.Browser.FindElement(By.XPath("//button[@class='location-selector__button']")).Click();
        IWebElement dropDown = BrowserFactory.Browser.FindElement(By.XPath("//nav[@class='location-selector__panel']"));
        Waiters.WaitForCondition(() => dropDown.Displayed);
        IEnumerable<string> listOfActualLanguages =
            BrowserFactory.Browser.FindElements(By.XPath("//li[@class='location-selector__item']")).ToList().Select(l => l.GetAttribute("outerText"));
        CollectionAssert.AreEquivalent(listOfLanguagesPage.listOfLanguages,listOfActualLanguages);
    }
}