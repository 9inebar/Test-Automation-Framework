using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Core.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Epam.TestAutomation.Tests.BDD.Steps.GeneralSteps;

[Binding]
public class SetUpSteps
{
    [BeforeFeature]
    public static void SetUpLogger()
    {
        Logger.InitLogger(TestContext.CurrentContext.Test.Name, TestContext.CurrentContext.TestDirectory);
    }
    
    [BeforeScenario]
    public static void SetUp()
    {
        Logger.Info("Test Begins");
        BrowserFactory.Browser.Maximize();
    }
}