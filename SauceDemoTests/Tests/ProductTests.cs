using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
using Allure.NUnit;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

[AllureNUnit]

public class ProductTests : BaseTests
{
    [SetUp]
    public void SetUp()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductPage productPage = loginPage.Login();
    }

   [Test]
    [AllureName("Product's elements checkout")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureDescription("Login with valid credentials")]
    public void AllProductsHaveRequiredElements()
    {
    AllureApi.Step("Product's elements checkout.", () =>
    {
        ProductPage productPage = new ProductPage(driver);
        Assert.That(productPage.IsLoaded(), Is.True);
        Assert.That(productPage.ProductsHaveRequiredElements(), Is.True);
    });
}
    
    [Test]
    [AllureName("Product's elements checkout")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureDescription("Navigation from Cart page to Product page")]
    public void NavigateFromCartPage()
    {
        ProductPage productPage = new ProductPage(driver);
        CartPage cartPage = productPage.OpenCart();
        AllureApi.Step("Product's elements checkout.", () =>
        {
            cartPage.ContinueShopping();
            Assert.That(productPage.IsTitleDisplayed(), Is.True);
        });
    }

    [Test]
    [AllureName("Cart counter")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureDescription("Cart counter changes after adding/removing a product")]
    public void GetCartCounter()
    {
        int expectedProducts = 3;
        ProductPage productPage = new ProductPage(driver);
        AllureApi.Step("Add new product to cart", () =>
        {
            productPage.AddToCart();
            productPage.AddToCart();
            productPage.AddToCart();
            Assert.That(productPage.GetCartCounter(), Is.EqualTo(expectedProducts));
        });
    }
}