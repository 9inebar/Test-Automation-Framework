using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using Epam.TestAutomation.Web.PageObjects.Pages;
using NUnit.Framework;
using Logger = Epam.TestAutomation.Core.Utils.Logger;

namespace Epam.TestAutomation.Tests;
[TestFixture]
public abstract class BaseTest
{
    public TestContext TestContext { get; set; }
    private MainPage mainPage = new();

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Logger.InitLogger(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.TestDirectory);
    }

    [SetUp]
    public virtual void BeforeTest()
    {
        Logger.Info("Test has begun");
        BrowserFactory.Browser.Maximize();
        BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl);
        Waiters.WaitForPageLoad();
        mainPage.AcceptAllCookies();
    }

    [TearDown]
    public virtual void CleanTest()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Logger.Info("Test has failed");
            BrowserFactory.Browser.SaveScreenShot(TestContext.CurrentContext.Test.MethodName, 
                Path.Combine(TestContext.CurrentContext.TestDirectory, TestSettings.ScreenShotPath));
        }
        Logger.Info("Test has finished");
        BrowserFactory.Browser.Close();
    }
}