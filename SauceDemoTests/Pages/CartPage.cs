using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoTests.Elements;
using SeleniumExtras.PageObjects;

namespace SauceDemoTests.Pages;

public class CartPage : LoadablePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(CartPage));
    // private readonly Button _checkoutButton;
    // private readonly Button _continueShoppingButton;
    // private readonly Button _removeProduct;
    // private readonly BaseElement _cartQuantity;
    // private readonly By _cartProducts = By.CssSelector("[data-test='inventory-item']");
    // private readonly By _removeButtons = By.XPath("//button[contains(text(), 'Remove')]");
    
    [FindsBy(How = How.Id, Using = "checkout")]
    private IWebElement _checkoutButton;
    
    [FindsBy(How = How.Id, Using = "continue-shopping")]
    private IWebElement _continueShoppingButton;
    
    [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Remove')]")]
    private IList<IWebElement> _removeButtons;
    
    [FindsBy(How = How.CssSelector, Using = "[data-test='item-quantity']")]
    private IWebElement _cartQuantity;
    
    [FindsBy(How = How.CssSelector, Using = "[data-test='inventory-item']")]
    private IList<IWebElement> _cartProducts;
    
    public CartPage(IWebDriver driver) : base(driver)
    {
        // _checkoutButton = new Button(driver, By.Id("checkout"));
        // _continueShoppingButton = new Button(driver, By.Id("continue-shopping"));
        // _removeProduct = new Button(driver, By.XPath("(//button[contains(@class, 'cart_button')])[1]"));
        // _cartQuantity = new BaseElement(driver, By.CssSelector("[data-test='item-quantity']"));
        PageFactory.InitElements(driver, this);
    }
    public override bool IsLoaded()
    {
        logger.Info("Checking that Cart page is loaded");
        WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        return Wait.Until(driver => _checkoutButton.Displayed);
    }
    public CheckoutPage Checkout()
    {
        logger.Info("Clicking Checkout button");
        _checkoutButton.Click();
        return new CheckoutPage(_driver);
    }
    
    public ProductPage ContinueShopping()
    {
       _continueShoppingButton.Click();
        return new ProductPage(_driver);   
    }

    public CartPage RemoveProduct()
    {
        if (_removeButtons.Count == 0)
        {
            throw new InvalidOperationException("No products to remove");
        }
        _removeButtons[0].Click();
        return this;
    }
    
    public bool IsProductDisplayed()
    {
        return _cartQuantity.Displayed;
    } 
    
    public int GetRemoveButtonsCount()
    {
        return _removeButtons.Count;
    }

    public bool ProductsHaveRequiredElements()
    {
        logger.Info("Checking if products contain all elements in the cart");
        foreach (var cartProductElement in _cartProducts)
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