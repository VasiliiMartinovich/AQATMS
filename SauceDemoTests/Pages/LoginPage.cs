using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SauceDemoTests.Pages;

public class LoginPage : LoadablePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(LoginPage));

    //private readonly TextField _userNameField;
    //private readonly TextField _passwordField;
    //private readonly Button _loginButton;
    //private readonly BaseElement _errorMessage;

    [FindsBy(How = How.Id, Using = "user-name")]
    private IWebElement _userNameField;
    
    [FindsBy(How = How.CssSelector, Using = "input[data-test='password']")]
    private IWebElement _passwordField;
    
    [FindsBy(How = How.Id, Using = "login-button")]
    private IWebElement _loginButton;
    
    [FindsBy(How = How.CssSelector, Using = "h3[data-test='error']")]
    private IWebElement _errorMessage;
    
    public LoginPage(IWebDriver driver) : base(driver)
    {
        //_userNameField = new TextField(driver, By.Id("user-name"));
        //_passwordField = new TextField(driver, By.CssSelector("input[data-test='password']"));
        //_loginButton = new Button(driver, By.Id("login-button"));
        //_errorMessage = new BaseElement(driver, By.CssSelector("h3[data-test='error']"));
        PageFactory.InitElements(driver, this);
    }

    public LoginPage Open()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => _loginButton.Displayed);
        return this;
    }

    public override bool IsLoaded()
    {
        logger.Info("Checking that Login page is loaded");
        WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        return Wait.Until(driver => _loginButton.Displayed);
    }
    public LoginPage SetUserName(string username)
    {
        logger.Info("Entering username");
        _userNameField.Clear();
        _userNameField.SendKeys(username);
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        logger.Info("Entering password");
        _passwordField.Clear();
        _passwordField.SendKeys(password);
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
        string errorMessage = _errorMessage.Text;
        logger.Info($"Login error message: {errorMessage}");
        return errorMessage;
    }

    public bool IsLoginPageDisplayed()
    {
        logger.Info("Checking that Login page is displayed");
        bool isDisplayed = _loginButton.Displayed
                           && _userNameField.Displayed
                           && _passwordField.Displayed;
        logger.Info($"Login page displayed: {isDisplayed}");
        return isDisplayed;
    }
}