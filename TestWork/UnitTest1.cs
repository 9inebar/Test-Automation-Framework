using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestWork;

public class Tests
{
    private IWebDriver driver { get; set; }
    private string epamUrl = "https://www.epam.com/";
    private Actions action;
    private WebDriverWait waiter;
    
    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.BinaryLocation = "/Applications/Google Chrome.app/Contents/MacOS/Google Chrome";
        driver = new ChromeDriver(options);
        action = new Actions(driver);
        waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
    }

    [Test]
    public void Test4()
    {
        driver.FindElement(By.XPath("//a[@data-item='0']"));
        driver.FindElement(By.XPath("//a[@data-item='1']"));
        driver.FindElement(By.XPath("//a[@data-item='2']"));
    }
    [Test]
    public void Test5()
    {
            var epamUrl = "https://www.epam.com/";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(epamUrl);
            Assert.That(driver.Url, Is.EqualTo(epamUrl), "The header element is not displayed on the page correctly");
    }
    [Test]
    public void Test6()
    {
        var jobListingsUrl = "https://www.epam.com/careers/locations";

        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(epamUrl);
        action.MoveToElement(driver.FindElement(By.XPath("//*[text()='Careers']//ancestor::*[@class='top-navigation__item-link js-op']"))).Build().Perform();
        Thread.Sleep(3000);    action.MoveToElement(driver.FindElement(By.XPath("//a[@href='/careers/locations']//parent::li[contains(@class, 'top')]"))).Click().Build().Perform();
        Assert.That(driver.Url,Is.EqualTo(jobListingsUrl), "the opened page has wrong url");
    }
}