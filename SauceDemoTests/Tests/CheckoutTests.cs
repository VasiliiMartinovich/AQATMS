using Allure.Net.Commons.Attributes;
using Allure.NUnit;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

[AllureNUnit]

public class CheckoutTests : BaseTests
{
    [SetUp]
    public void SetUp()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductPage productPage = loginPage.Login();
        productPage.AddToCart();
        CartPage cartPage = productPage.OpenCart();
        cartPage.Checkout();
    }
    [Test]
    [AllureName("Checkout page displays ")]
    public void CheckoutPageDisplayed()
    {
        CheckoutPage checkoutPage = new CheckoutPage(driver);
        Assert.That(checkoutPage.IsLoaded(), Is.True);
        Assert.That(checkoutPage.IsCheckoutPageDisplayed(), Is.True);
    }
}