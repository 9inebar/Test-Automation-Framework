using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;

namespace Epam.TestAutomation.Tests;

[TestFixture] [Parallelizable(ParallelScope.All)]
public class ListOfLanguagesTests : BaseTest
{
    [Test]
    public void VerifyListOfLangIsCorrect()
    {
        MainPage.LangBlock.DropDownButton.Click();
        Waiters.WaitForCondition(() => MainPage.LangBlock.DropDownMenu.Displayed);
        List<string> listOfLanguages = new List<string> { "Global (English)", "Česká Republika (Čeština)", "Czech Republic (English)", "DACH (Deutsch)", "Hungary (English)", "India (English)", "日本 (日本語)","Polska (Polski)","СНГ (Русский)", "Україна (Українська)", "中国 (中文)"};
        IEnumerable<string> listOfActualLanguages =
            MainPage.LangBlock.DropDownOption.Select(l => l.GetAttribute("outerText"));
        CollectionAssert.AreEquivalent(listOfLanguages,listOfActualLanguages);
    }
}