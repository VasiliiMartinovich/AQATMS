using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.Pages;

public class HeaderSection : BasePage
{
    private readonly By _btnBurgerMenu = By.Id("react-burger-menu-btn");
    private readonly By _btnLogout = By.Id("logout_sidebar_link");
    public HeaderSection(IWebDriver driver) : base(driver)
    {
    }

    public HeaderSection OpenSideBar()
    {
        _driver.FindElement(_btnBurgerMenu).Click();
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); //ожидание 10 секунд, пока кнопка логаут не станет Displayed. 
        wait.Until(e => e.FindElement(_btnLogout).Displayed);

        return this;
    }

    public LoginPage ClickLogoutButton()
    {
        _driver.FindElement(_btnLogout).Click();
        return new LoginPage(_driver);
    }
    public LoginPage Logout()
    {
        return OpenSideBar().ClickLogoutButton();
    }
}