using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SauceDemoTests.Pages;

public class HeaderSection : BasePage
{
    [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
    private IWebElement _burgerMenu;

    [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
    private IWebElement _logoutButton;

    public HeaderSection(IWebDriver driver) : base(driver)
    {
        PageFactory.InitElements(driver, this);
    }

    public HeaderSection OpenSideBar()
    {
        _burgerMenu.Click();
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => _logoutButton.Displayed);
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
