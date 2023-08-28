using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Epam.TestAutomation.Core.Helper;
using Epam.TestAutomation.Core.ScreenShot;
using Epam.TestAutomation.Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Epam.TestAutomation.Core.Browser;

public class Browser
{
    private IWebDriver driver { get;}
    //private Actions action { get; set; }
    IJavaScriptExecutor jse => (IJavaScriptExecutor)driver;

    public Browser(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void ScrollToElements(IWebElement element)
    {
        Logger.Info("The page is scrolled to the specified element");
        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        jse.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)", element);
    }

    public void ClickElement(By locator)
    {
        Logger.Info("Click on element");
        driver.FindElement(locator).Click();
    }
    public void EnterText(By locator, string text)
    {
        Logger.Info("Enter text");
        driver.FindElement(locator).SendKeys(text);
    }
    public void Back()
    {
        Logger.Info("Navigate Back");
        driver.Navigate().Back();
    }

    public string GetUrl()
    {
        Logger.Info("Get the current browser's session url");
        return driver.Url;
    }

    public void Maximize()
    {
        Logger.Info("Maximize the browser window");
        driver.Manage().Window.Maximize();
    }

    public void Refresh()
    {
        Logger.Info("Refresh page");
        driver.Navigate().Refresh();
    }

    public void GoToUrl(string url)
    {
        Logger.Info($"Open url: {url}");
        driver.Navigate().GoToUrl(url);
    }

    public void ScrollTop()
    {
        Logger.Info("The page is scrolled to the very top");
        jse.ExecuteScript("$(window).scrollTop(0)");
    }

    public void Close()
    {
        Logger.Info("Close current tab");
        driver.Close();
    }

    public void Quit()
    {
        Logger.Info("Close the browser");
        try
        {
            driver.Quit();
        }
        catch (Exception ex)
        {
            Logger.Info($"Unable to close the browser. Reason: {ex.Message}");
        }
    }

    public string Url
    {
        get => driver.Url;
        set => driver.Url = value;
    }

    public void SaveScreenShot(string screenshotName, string folderPath)
    {
        try
        {
            Logger.Info("Generation of screenshot has started");
            ScreenshotTaker.TakeScreenshot(driver, screenshotName, folderPath);
            Logger.Info("Generation of screenshot has finished");
        }
        catch (Exception ex)
        {
            Logger.Info($"Failed to capture the screenshot. Exception message {ex.Message}");
        }
    }
    public WebDriverWait Waiters => new WebDriverWait(driver, TestSettings.WebDriverTimeOut);
    public Actions Action => new Actions(driver);
    
    public object ExecuteScript(string script, params object[] args)
    {
        try
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(script, args);
        }
        catch (WebDriverTimeoutException e)
        {
            // If timeout or any errors
            Logger.Info($"Error: Timeout Exception thrown while running JS Script:{e.Message}-{e.StackTrace}");
        }
        return null;
    }
    public IWebElement FindElement(By locator)
    {
        return driver.FindElement(locator);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return driver.FindElements(by);
    }
}