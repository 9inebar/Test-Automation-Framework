using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Core.Browser;
using Epam.TestAutomation.Web.PageObjects.Panels;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class MainPage : BasePage
{
    public override string Url => "https://www.epam.com/";

    public FooterBlock FooterBlock => new FooterBlock(By.XPath("//*[@class='footer section']"));

    public HeaderBlock HeaderBlock => new HeaderBlock(By.XPath("//*[@class = 'header__content']"));

    public ListOfLanguagesBlock LangBlock => new (By.XPath("//button[@class='location-selector__button']"));
    
    public IWebElement SearchForm => BrowserFactory.Browser.FindElement(By.XPath("//input[@id='new_form_search']"));
    public By SearchButton = By.XPath("//*[@class='header-search__button header__icon']");
    public IWebElement FindButton = BrowserFactory.Browser.FindElement(By.XPath("//span[@class='bth-text-layer']"));
    public readonly IWebElement FrequentSearchesFirstItem = BrowserFactory.Browser.FindElement(By.XPath("//li[@class='frequent-searches__item'][1]"));
    public By EmptyBar = By.XPath("//*[@id='onetrust-consent-sdk']");
    public By MobileLocationSelector = (By.XPath("//*[@class='mobile-location-selector__link active']//ancestor::*[@href='https://www.epam.com']"));
    public By VendorSearch = By.XPath("//*[@name='vendor-search-handler']");
    public By MenuDropDown = By.XPath("//nav[@class='hamburger-menu__dropdown']");
    public By ContactUsButton = By.XPath("//*[@class='hamburger-menu__item cta-button-menu-item']//span[@class='cta-button__text']");
    public IWebElement CareersButton = BrowserFactory.Browser.FindElement(By.XPath("//a[@ href='/careers']//parent::span"));
}