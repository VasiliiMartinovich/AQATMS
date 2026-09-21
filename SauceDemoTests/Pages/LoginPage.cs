using log4net;
using OpenQA.Selenium;
using SauceDemoTests.Elements;


namespace SauceDemoTests.Pages;

public class LoginPage : BasePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(LoginPage));

    private readonly TextField _userNameField;
    private readonly TextField _passwordField;
    private readonly Button _loginButton;
    private readonly BaseElement _errorMessage;
    
    public LoginPage(IWebDriver driver) : base(driver)
    {
        _userNameField = new TextField(driver, By.Id("user-name"));
        _passwordField = new TextField(driver, By.CssSelector("input[data-test='password']"));
        _loginButton = new Button(driver, By.Id("login-button"));
        _errorMessage = new BaseElement(driver, By.CssSelector("h3[data-test='error']"));
    }

    public LoginPage SetUserName(string username)
    {
        logger.Info("Entering username");
        _userNameField.SetValue(username);
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        logger.Info("Entering password");
        _passwordField.SetValue(password);
        return this;
    }

    public ProductPage ClickLoginButton()
    {
        logger.Info("Clicking Login button");
        _loginButton.Click();
        return new ProductPage(_driver);
    }

    public ProductPage Login(string username = "standard_user", string password = "secret_sauce")
    {
        return SetUserName(username).SetPassword(password).ClickLoginButton();
    }

    public string? GetErrorMessage()
    {
        logger.Info("Getting login error message");
        string errorMessage = _errorMessage.GetText();
        logger.Info($"Login error message: {errorMessage}");
        return errorMessage;
    }

    public bool IsLoginPageDisplayed()
    {
        logger.Info("Checking that Login page is displayed");
        bool isDisplayed = _loginButton.IsDisplayed()
                           && _userNameField.IsDisplayed()
                           && _passwordField.IsDisplayed();
        logger.Info($"Login page displayed: {isDisplayed}");
        return isDisplayed;
    }
}