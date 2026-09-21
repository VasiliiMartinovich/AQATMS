using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
using Allure.NUnit;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

[AllureNUnit]

public class PurchaseTests : BaseTests
{

    [Test]
    [AllureName("Full Purchase flow")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.critical)]
    public void FullPurchaseFlow()
    {
        ProductPage productPage = null!;
        CartPage cartPage = null!;
        CheckoutPage checkoutPage = null!;
        OverviewPage overviewPage = null!;

        AllureApi.Step("Login with valid credentials.", () =>
        {
            LoginPage loginPage = new LoginPage(driver);
            productPage = loginPage.Login();
            Assert.That(productPage.IsCartIconDisplayed(), Is.True);
        });

        AllureApi.Step("Add product to cart.", () =>
        {
            productPage.AddToCart();
        });

        AllureApi.Step("Open shopping cart.", () =>
        {
            cartPage = productPage.OpenCart();
        });

        AllureApi.Step("Verify product is added to cart", () =>
        {
            Assert.That(cartPage.IsProductDisplayed(), Is.True);
            Assert.That(cartPage.ProductsHaveRequiredElements(), Is.True);
        });

        AllureApi.Step("Proceed to checkout", () =>
        {
            checkoutPage = cartPage.Checkout();
        });

        AllureApi.Step("Verify checkout page", () =>
        {
            Assert.That(checkoutPage.IsCheckoutPageDisplayed(), Is.True);
        });

        AllureApi.Step("Enter customer information", () =>
        {
            checkoutPage.SetCustomerInformation("John", "Ivanov", "92012");
        });
        
        AllureApi.Step("Check overview", () =>
        {
            overviewPage = checkoutPage.ClickContinueButton();
            Assert.That(overviewPage.IsFinishButtonDisplayed(), Is.True);
        });

        AllureApi.Step("Complete purchase", () =>
        {
            overviewPage.ClickFinishButton();
            Assert.That(overviewPage.IsSuccessMessageDisplayed(), Is.True);
        });
    }
}