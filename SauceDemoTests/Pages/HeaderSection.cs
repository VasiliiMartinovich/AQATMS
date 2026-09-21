using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoTests.Elements;

namespace SauceDemoTests.Pages;

public class HeaderSection : BasePage
{
    private readonly Button _burgerMenu;
    private readonly Link _logoutButton;
    public HeaderSection(IWebDriver driver) : base(driver)
    {
        _burgerMenu = new Button(driver, By.Id("react-burger-menu-btn"));
        _logoutButton = new Link(driver, By.Id("logout_sidebar_link"));
    }

    public HeaderSection OpenSideBar()
    {
        _burgerMenu.Click();
        _logoutButton.WaitUntilDisplayed();
        return this;
    }

    public LoginPage ClickLogoutButton()
    {
        _logoutButton.Click();
        return new LoginPage(_driver);
    }
    public LoginPage Logout()
    {
        return OpenSideBar().ClickLogoutButton();
    }
}