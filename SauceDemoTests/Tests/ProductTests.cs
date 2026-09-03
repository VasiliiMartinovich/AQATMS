using OpenQA.Selenium.Chrome;
using SauceDemoTests.Pages;
namespace SauceDemoTests.Tests;

public class ProductTests : BaseTests
{
    [SetUp]
    public void SetUp()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductPage productPage = loginPage.Login();
    }
    
    [Test]
    public void AllProductsHaveRequiredElements()
    {
        ProductPage productPage = new ProductPage(driver);
        Assert.That(productPage.ProductsHaveRequiredElements(), Is.True);
    }
    
    [Test]
    public void NavigateFromCartPage()
    {
        ProductPage productPage = new ProductPage(driver);
        CartPage cartPage = productPage.OpenCart();
        cartPage.ContinueShopping();
        Assert.That(productPage.IsTitleDisplayed(), Is.True);
    }

    [Test]
    public void GetCartCounter()
    {
        int expectedProducts = 3;
        ProductPage productPage = new ProductPage(driver);
        productPage.AddToCart();
        productPage.AddToCart();
        productPage.AddToCart();
        Assert.That(productPage.GetCartCounter(), Is.EqualTo(expectedProducts));
    }
}