using Allure.Net.Commons;
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
        Assert.That(checkoutPage.IsCheckoutPageDisplayed(), Is.True);
    }
    [Test]
    [AllureName("Purchase flow")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureDescription("Product buy flow")]
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