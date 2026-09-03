using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

public class CartTests : BaseTests
{
    [SetUp]
    public void SetUp()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductPage productPage = loginPage.Login();
    }
    
    [Test]
    public void AddProductToCart()
    {
        ProductPage productPage = new ProductPage(driver);
        productPage.AddToCart();
        CartPage cartPage = productPage.OpenCart();
        Assert.That(cartPage.IsProductDisplayed(), Is.True);
    }
    
    [Test]
    public void RemoveProductFromCart()
    {
        ProductPage productPage = new ProductPage(driver);
        productPage.AddToCart();
        productPage.AddToCart();
        CartPage cartPage = productPage.OpenCart();
        Assert.That(cartPage.GetRemoveButtonsCount(), Is.EqualTo(2));
        cartPage.RemoveProduct();
        Assert.That(cartPage.GetRemoveButtonsCount(), Is.EqualTo(1));
    }
    
    [Test]
    public void EmptyCartCheck()
    {
        ProductPage productPage = new ProductPage(driver);
        CartPage cartPage = productPage.OpenCart();
        Assert.That(cartPage.GetRemoveButtonsCount(), Is.EqualTo(0));
    }
    
    [Test]
    public void NavigateToCart()
    {
        ProductPage productPage = new ProductPage(driver);
        CartPage cartPage = productPage.OpenCart();
        Assert.That(cartPage.IsCheckoutDisplayed(), Is.True);
    }
    
    [Test]
    public void ProductsHaveRequiredElements()
    {
        ProductPage productPage = new ProductPage(driver);
        productPage.AddToCart();
        CartPage cartPage = productPage.OpenCart();
        Assert.That(cartPage.ProductsHaveRequiredElements(), Is.True);
    }
}