using log4net;
using OpenQA.Selenium;
using SauceDemoTests.Elements;

namespace SauceDemoTests.Pages;

public class ProductPage : BasePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(LoginPage));
    
    private readonly Link _shoppingCart;
    private readonly Label _shoppingCartCounter;
    private readonly Button _addToCart;
    private readonly BaseElement _title;

    private readonly By _productItems = By.CssSelector("[data-test='inventory-item']");
    public ProductPage(IWebDriver driver) : base(driver)
    {
        _shoppingCart = new Link(driver, By.CssSelector(".shopping_cart_link"));
        _shoppingCartCounter = new Label(driver,By.CssSelector(".shopping_cart_badge"));
        _addToCart = new Button(driver, By.CssSelector(".btn.btn_primary.btn_small"));
        _title = new BaseElement(driver, By.CssSelector(".title"));
    }
    
    public HeaderSection Header => new (_driver);
    
    public bool IsCartIconDisplayed()
    {
        return _shoppingCart.IsDisplayed();
    }

    public ProductPage AddToCart()
    {
        logger.Info("Adding an item to the cart");
        _addToCart.Click();
        return this;
    }

    public int GetCartCounter()
    {
        return int.Parse(_shoppingCartCounter.GetText());
    }

    public bool IsTitleDisplayed()
    {
        return _title.IsDisplayed();
    }

    public CartPage OpenCart()
    {
        logger.Info("Opening the cart");
        _shoppingCart.Click();
        return new CartPage(_driver);
    }
    
    public bool ProductsHaveRequiredElements()
    {
        var productElements = _driver.FindElements(_productItems);

        foreach (var productElement in productElements)
        {
            var product = new ProductItem(productElement);

            if (!product.HasRequiredElements())
            {
                return false;
            }
        }
        return true;
    }
}