using OpenQA.Selenium;

namespace SauceDemoTests.Pages;

public class LoginPage : BasePage
{
    private readonly By _userNameField = By.Id("user-name");
    private readonly By _passwordField = By.CssSelector("input[data-test='password']");
    private readonly By _loginButton = By.Id("login-button");
    private readonly By _errorMessage = By.CssSelector("h3[data-test='error']");
    
    public LoginPage(IWebDriver driver) : base (driver)
    {
        _driver = driver;
    }
    
    public LoginPage SetUserName(string username)
    {
        _driver.FindElement(_userNameField).SendKeys(username);
        return this;
    }
    
    public LoginPage SetPassword(string password )
    {
        _driver.FindElement(_passwordField).SendKeys(password);
        return this;
    }
    
    public ProductPage ClickLoginButton()
    {
        _driver.FindElement(_loginButton).Click();
        return new ProductPage(_driver);
    }
    
    public ProductPage Login(string username = "standard_user", string password = "secret_sauce")
    {
        return SetUserName(username).SetPassword(password).ClickLoginButton();
    }
    
    public string? GetErrorMessage() => 
        _driver.FindElement(_errorMessage)?.Text;

    public bool IsLoginPageDisplayed() =>
        _driver.FindElement(_loginButton).Displayed
        && _driver.FindElement(_userNameField).Displayed
        && _driver.FindElement(_passwordField).Displayed;
}