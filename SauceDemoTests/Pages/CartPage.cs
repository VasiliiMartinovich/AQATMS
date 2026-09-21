using log4net;
using OpenQA.Selenium;
using SauceDemoTests.Elements;

namespace SauceDemoTests.Pages;

public class CartPage : BasePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(LoginPage));
    private readonly Button _checkoutButton;
    private readonly Button _continueShoppingButton;
    private readonly Button _removeProduct;
    private readonly BaseElement _cartQuantity;
    private readonly By _cartProducts = By.CssSelector("[data-test='inventory-item']");
    private readonly By _removeButtons = By.XPath("//button[contains(text(), 'Remove')]");
    public CartPage(IWebDriver driver) : base(driver)
    {
        _checkoutButton = new Button(driver, By.Id("checkout"));
        _continueShoppingButton = new Button(driver, By.Id("continue-shopping"));
        _removeProduct = new Button(driver, By.XPath("(//button[contains(@class, 'cart_button')])[1]"));
        _cartQuantity = new BaseElement(driver, By.CssSelector("[data-test='item-quantity']"));
    }
   
    public CheckoutPage Checkout()
    {
        _checkoutButton.Click();
        return new CheckoutPage(_driver);
    }
    
    public bool IsCheckoutDisplayed()
    {
        return _checkoutButton.IsDisplayed();
    }

    public ProductPage ContinueShopping()
    {
       _continueShoppingButton.Click();
        return new ProductPage(_driver);   
    }

    public CartPage RemoveProduct()
    {
        _removeProduct.Click();
        return this;
    }
    
    public bool IsProductDisplayed()
    {
        return _cartQuantity.IsDisplayed();
    } 
    
    public int GetRemoveButtonsCount()
    {
        return _driver.FindElements(_removeButtons).Count;
    }

    public bool ProductsHaveRequiredElements()
    {
        logger.Info("Checking if products contain all elements in the cart");
        var cartProducts = _driver.FindElements(_cartProducts);
        foreach (var cartProductElement in cartProducts)
        {
            var cartItem = new CartItem(cartProductElement);
            if (!cartItem.HasRequiredElements())
            {
                return false;
            }
        }
        return true;
    }
}