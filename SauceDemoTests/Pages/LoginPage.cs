using log4net;
using OpenQA.Selenium;

namespace SauceDemoTests.Pages;

public class LoginPage : BasePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(LoginPage));

    private readonly By _userNameField = By.Id("user-name");
    private readonly By _passwordField = By.CssSelector("input[data-test='password']");
    private readonly By _loginButton = By.Id("login-button");
    private readonly By _errorMessage = By.CssSelector("h3[data-test='error']");

    public LoginPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    public LoginPage SetUserName(string username)
    {
        logger.Info("Entering username");
        _driver.FindElement(_userNameField).SendKeys(username);
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        logger.Info("Entering password");
        _driver.FindElement(_passwordField).SendKeys(password);
        return this;
    }

    public ProductPage ClickLoginButton()
    {
        logger.Info("Clicking Login button");
        _driver.FindElement(_loginButton).Click();
        return new ProductPage(_driver);
    }

    public ProductPage Login(string username = "standard_user", string password = "secret_sauce")
    {
        return SetUserName(username).SetPassword(password).ClickLoginButton();
    }

    public string? GetErrorMessage()
    {
        logger.Info("Getting login error message");
        string errorMessage = _driver.FindElement(_errorMessage)?.Text;
        logger.Info($"Login error message: {errorMessage}");
        return _driver.FindElement(_errorMessage)?.Text;
    }

    public bool IsLoginPageDisplayed()
    {
        logger.Info("Checking that Login page is displayed");
        bool isDisplayed = _driver.FindElement(_loginButton).Displayed
                           && _driver.FindElement(_userNameField).Displayed
                           && _driver.FindElement(_passwordField).Displayed;
        logger.Info($"Login page displayed: {isDisplayed}");
        return isDisplayed;
    }
}