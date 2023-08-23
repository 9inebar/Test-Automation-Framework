using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;

namespace Epam.TestAutomation.Tests;

public class MainPageTests : BaseTest
{
    private MainPage mainPage;

    [SetUp]
    public void SetUp()
    {
        mainPage = new MainPage();
    }

    [Test]
    public void MainPageIsOpenedTest()
    {
        Assert.IsTrue(mainPage.Title.IsDisplayed(), "Page doesn't open");
    }
}