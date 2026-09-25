using log4net;
using OpenQA.Selenium;
using SauceDemoTests.Elements;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SauceDemoTests.Pages;

public class ProductPage : LoadablePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(ProductPage));
    
    // private readonly Link _shoppingCart;
    // private readonly Label _shoppingCartCounter;
    // private readonly Button _addToCart;
    // private readonly BaseElement _title;

    [FindsBy(How = How.CssSelector, Using = ".shopping_cart_link")]
    private IWebElement _shoppingCart;
    
    [FindsBy(How = How.CssSelector, Using = ".shopping_cart_badge")]
    private IWebElement _shoppingCartCounter;
    
    [FindsBy(How = How.CssSelector, Using = ".btn.btn_primary.btn_small")]
    private IWebElement _addToCart;
    
    [FindsBy(How = How.CssSelector, Using = ".title")]
    private IWebElement _title;
    
    
    private readonly By _productItems = By.CssSelector("[data-test='inventory-item']");
    public ProductPage(IWebDriver driver) : base(driver)
    {
        // _shoppingCart = new Link(driver, By.CssSelector(".shopping_cart_link"));
        // _shoppingCartCounter = new Label(driver,By.CssSelector(".shopping_cart_badge"));
        // _addToCart = new Button(driver, By.CssSelector(".btn.btn_primary.btn_small"));
        // _title = new BaseElement(driver, By.CssSelector(".title"));
        PageFactory.InitElements(driver, this);
    }
    
   public override bool IsLoaded()
    {
        logger.Info("Checking that Product page is loaded");
        WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        return Wait.Until(driver => _title.Displayed);
    }
    
    public HeaderSection Header => new (_driver);
    
    public bool IsCartIconDisplayed()
    {
        return _shoppingCart.Displayed;
    }

    public ProductPage AddToCart()
    {
        logger.Info("Adding an item to the cart");
        _addToCart.Click();
        return this;
    }

    public int GetCartCounter()
    {
        return int.Parse(_shoppingCartCounter.Text);
    }

    public bool IsTitleDisplayed()
    {
        return _title.Displayed;
    }

    public CartPage OpenCart()
    {
        logger.Info("Opening the cart");
        _shoppingCart.Click();
        return new CartPage(_driver);
    }
    
    public bool ProductsHaveRequiredElements()
    {
        logger.Info("Check that product has all required elements");
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