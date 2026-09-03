using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace SauceDemoTests.Pages;

public class CartPage : BasePage
{
    public CartPage(IWebDriver driver) : base(driver)
    {
    }
    private readonly By _checkoutButton = By.Id("checkout");
    private readonly By _continueShoppingButton = By.Id("continue-shopping");
    private readonly By _removeProduct = By.XPath("(//button[contains(@class, 'cart_button')])[1]");
    private readonly By _cartQty = By.CssSelector("[data-test='item-quantity']");

    public CheckoutPage Checkout()
    {
        _driver.FindElement(_checkoutButton).Click();
        return new CheckoutPage(_driver);
    }
    
    public bool IsCheckoutDisplayed()
    {
        return _driver.FindElement(_checkoutButton).Displayed;
    }

    public ProductPage ContinueShopping()
    {
        _driver.FindElement(_continueShoppingButton).Click();
        return new ProductPage(_driver);   
    }

    public CartPage RemoveProduct()
    {
        _driver.FindElement(_removeProduct).Click();
        return this;
    }
    
    public bool IsProductDisplayed()
    {
        return _driver.FindElement(_cartQty)?.Displayed ?? false;
    } 
    
    public int GetRemoveButtonsCount()
    {
        return _driver.FindElements(By.XPath("//button[contains(text(), 'Remove')]")).Count;
    }

    public bool ProductsHaveRequiredElements()
    {
        var cartProducts = _driver.FindElements(
            By.CssSelector("[data-test='inventory-item']"));

        foreach (var product in cartProducts)
        {
            if (!product.FindElement(By.ClassName("cart_quantity")).Displayed)
                return false;
            if (!product.FindElement(By.ClassName("cart_item_label")).Displayed)
                return false;

            if (!product.FindElement(By.ClassName("inventory_item_desc")).Displayed)
                return false;

            if (!product.FindElement(By.ClassName("item_pricebar")).Displayed)
                return false;

            if (!product.FindElement(By.CssSelector(".btn.btn_secondary.btn_small")).Displayed)
                return false;
        }

        return true;
    }
}