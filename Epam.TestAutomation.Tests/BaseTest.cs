using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.Utils;
using NUnit.Framework;
using Logger = Epam.TestAutomation.Core.Utils.Logger;

namespace Epam.TestAutomation.Tests;

public abstract class BaseTest
{
    public TestContext TestContext { get; set; }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Logger.InitLogger(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.TestDirectory);
    }

    [SetUp]
    public virtual void BeforeTest()
    {
        Logger.Info("Test has begun");
        BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl);
        BrowserFactory.Browser.Refresh();
        Waiters.WaitForPageLoad();
    }

    [TearDown]
    public virtual void CleanTest()
    {
        
    }
}