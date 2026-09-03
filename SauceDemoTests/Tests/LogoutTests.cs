using SauceDemoTests.Pages;
namespace SauceDemoTests.Tests;

public class LogoutTests : BaseTests
{
    [Test]
    public void Logout()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductPage productPage = loginPage.Login();
        var newLoginPage = productPage.Header.Logout();
        Assert.That(newLoginPage.IsLoginPageDisplayed(), Is.True);
    }
}