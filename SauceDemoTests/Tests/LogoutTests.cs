using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
using Allure.NUnit;
using log4net;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;
[AllureNUnit]

public class LogoutTests : BaseTests
{
    private readonly ILog logger = LogManager.GetLogger(typeof(LogoutTests));
    
    [Test]
    [AllureName("Successful Log Out")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureDescription("Log out for authorized user")]
    public void Logout()
    {
        logger.Info("Test started: Logout");
        LoginPage loginPage = new LoginPage(driver);
        logger.Info("Logging in with valid credentials");
        ProductPage productPage = loginPage.Login();
        logger.Info("User successfully logged in");
        AllureApi.Step("Verify that user can successfully log out", () =>
        {
            logger.Info("Starting logout");
            var newLoginPage = productPage.Header.Logout();
            Assert.That(newLoginPage.IsLoginPageDisplayed(), Is.True);
            logger.Info("Logout completed");
        });
        logger.Info("Test finished: Logout");
    }
}
