using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
using Allure.NUnit;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

[AllureNUnit]

public class CartTests : BaseTests
{
    [SetUp]
    public void SetUp()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductPage productPage = loginPage.Login();
    }
    
    [Test]
    [AllureName("Adding an item to the cart")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureDescription("User can successfully add new item to the cart")]
    public void AddProductToCart()
    {
        AllureApi.Step("Adding an item to the cart", () =>
        {
            ProductPage productPage = new ProductPage(driver);
            productPage.AddToCart();
            CartPage cartPage = productPage.OpenCart();
            Assert.That(cartPage.IsLoaded(), Is.True);
            Assert.That(cartPage.IsProductDisplayed(), Is.True);
        });
    }
    
    [Test]
    [AllureName("Removing an item from the cart")]
    [AllureTag("regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureDescription("User can successfully remove an item from the cart")]
    public void RemoveProductFromCart()
    {
        AllureApi.Step("Adding an item to the cart", () =>
        {
            ProductPage productPage = new ProductPage(driver);
            productPage.AddToCart();
            productPage.AddToCart();
            AllureApi.Step("Checkout cart counter after adding", () =>
            {
                CartPage cartPage = productPage.OpenCart();
                Assert.That(cartPage.GetRemoveButtonsCount(), Is.EqualTo(2));

                AllureApi.Step("Checkout cart counter after removal", () =>
                {
                    cartPage.RemoveProduct();
                    Assert.That(cartPage.GetRemoveButtonsCount(), Is.EqualTo(1));
                });
            });
        });
    }
    
    [Test]
    [AllureName("Cart counter is empty")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureDescription("Empty cart has not any counter")]
    public void EmptyCartCheck()
    {
        ProductPage productPage = new ProductPage(driver);
        CartPage cartPage = productPage.OpenCart();
        Assert.That(cartPage.GetRemoveButtonsCount(), Is.EqualTo(0));
    }
    
    [Test]
    [AllureName("Navigation to the cart")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureDescription("Cart page successfully opens from product page")]
    public void NavigateToCart()
    {
        ProductPage productPage = new ProductPage(driver);
        CartPage cartPage = productPage.OpenCart();
        Assert.That(cartPage.IsLoaded(), Is.True);
    }
    
    [Test]
    [AllureName("Product elements checkout")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureDescription("Product has all necessary elements in the cart")]
    public void ProductsHaveRequiredElements()
    {
        ProductPage productPage = new ProductPage(driver);
        productPage.AddToCart();
        CartPage cartPage = productPage.OpenCart();
        Assert.That(cartPage.ProductsHaveRequiredElements(), Is.True);
    }
}
