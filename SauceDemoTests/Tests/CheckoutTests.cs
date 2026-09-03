using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

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
    public void CheckoutPageDisplayed()
    {
        CheckoutPage checkoutPage = new CheckoutPage(driver);
        Assert.That(checkoutPage.IsCheckoutPageDisplayed(), Is.True);
    }
    [Test]
    public void FullPurchaseFlow()
    {
        CheckoutPage checkoutPage = new CheckoutPage(driver);
        checkoutPage.SetFirstName("John").SetLastName("Doe").SetZipcode("83631");
        OverviewPage overviewPage = checkoutPage.ClickContinueButton();
        Assert.That(overviewPage.IsFinishButtonDisplayed(), Is.True);
        overviewPage.ClickFinishButton();
        Assert.That(overviewPage.IsSuccessMessageDisplayed(), Is.True);
    }
}