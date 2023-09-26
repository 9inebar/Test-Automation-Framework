using Epam.TestAutomation.Core.Helper;

namespace Epam.TestAutomation.Core.Browser;

public class BrowserFactory
{
    private static ThreadLocal<Browser> browser;

    static BrowserFactory()
    {
        browser = new ThreadLocal<Browser>(() => new Browser(DriverFactory.GetWebDriver(TestSettings.Browser)));
    }

    public static Browser Browser
    {
        get
        {
            browser.Value = browser.Value ?? new Browser(DriverFactory.GetWebDriver(TestSettings.Browser));
            return browser.Value;
        }
    }
}