using Epam.TestAutomation.Core.BasePage;
using Epam.TestAutomation.Web.PageObjects.Panels;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Web.PageObjects.Pages;

public class MainPage : BasePage
{
    public override string Url => "https://www.epam.com/";

    public FooterBlock FooterBlock => new FooterBlock(By.XPath("//*[@class='footer section']"));

    public HeaderBlock HeaderBlock => new HeaderBlock(By.XPath("//*[@class = 'header__content']"));

    public By searchButton = (By.XPath("//*[@class='header-search__button header__icon']"));
    public By emptyBar = (By.XPath("//*[@id='onetrust-consent-sdk']"));
    public By mobileLocationSelector = (By.XPath("//*[@class='mobile-location-selector__link active']//ancestor::*[@href='https://www.epam.com']"));
    public By vendorSearch = (By.XPath(("//*[@name='vendor-search-handler']")));
    public By menuDropDown = (By.XPath("//nav[@class='hamburger-menu__dropdown']"));
    
    public By contactUsButton = (By.XPath("//*[@class='hamburger-menu__item cta-button-menu-item']//span[@class='cta-button__text']"));
}