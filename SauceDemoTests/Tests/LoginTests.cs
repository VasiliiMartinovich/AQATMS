using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
using Allure.NUnit;
using log4net;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

[AllureNUnit]

public class LoginTest : BaseTests
{
    private readonly ILog logger = LogManager.GetLogger(typeof(LoginTest));
    
    [Test]
    [AllureName("LoginPageLoading")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.minor)]
    public void LoginPageShouldBeLoaded()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.Open();
        Assert.That(loginPage.IsLoaded(), Is.True);
    }
    
    [Test]
    [AllureName("Successful login")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureDescription("Login with valid credentials")]
    public void LoginSuccess()
    {
        logger.Info("Test started: LoginSuccess");
        LoginPage loginPage = new LoginPage(driver);
        loginPage.Open();
        Assert.That(loginPage.IsLoaded(), Is.True);
        AllureApi.Step("Successful login.", () =>
        {
            ProductPage productPage = loginPage.Login();
            logger.Info("Checking that cart icon is displayed");
            Assert.That(productPage.IsCartIconDisplayed(), Is.True);
        });
        logger.Info("Test finished: LoginSuccess");
    }
    
    [Test]
    [AllureName("Locked user login")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureDescription("Login with credentials of blocked user")]
    public void LoginLockedUser()
    {
        logger.Info("Test started: LoginLockedUser");
        LoginPage loginPage = new LoginPage(driver);

        AllureApi.Step("Login with locked user.", () =>
        {
            loginPage.SetUserName(username: "locked_out_user").SetPassword(password: "secret_sauce").ClickLoginButton();
            logger.Info("Checking locked user error message");
            Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
        });
        logger.Info("Test finished: LoginLockedUser");
    }
    
    [Test]
    [AllureName("Login page displays")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureDescription("Checkout that login page displays")]
    public void LoginPageDisplayed()
    { 
        logger.Info("Test started: LoginPageDisplayed");
        LoginPage loginPage = new LoginPage(driver);
        logger.Info("Checking Login page");
        Assert.That(loginPage.IsLoginPageDisplayed(), Is.True);
        logger.Info("Test finished: LoginPageDisplayed");
    }
}
