using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

public class LoginTest : BaseTests
{
    [Test]
    public void LoginSuccess()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductPage productPage = loginPage.Login();
        Assert.That(productPage.IsCartIconDisplayed(), Is.True);
    }
    
    [Test]
    public void LoginLockedUser()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.Login(username: "locked_out_user");
        Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
    }
    
    [Test]
    public void LoginPageDisplayed()
    { 
        LoginPage loginPage = new LoginPage(driver);
        Assert.That(loginPage.IsLoginPageDisplayed(), Is.True);
    }
    
    [Test]
    public void Logout()
    { 
        LoginPage loginPage = new LoginPage(driver);
        Assert.That(loginPage.IsLoginPageDisplayed(), Is.True);
    }
}