using OpenQA.Selenium;
namespace SauceDemoTests.Pages;

public class ProductPage : BasePage
{
    public ProductPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }
    
    private readonly By _shoppingCart = By.CssSelector(".shopping_cart_link");
    private readonly By _shoppingCartCounter = By.CssSelector(".shopping_cart_badge");
    private readonly By _addToCart = By.CssSelector(".btn.btn_primary.btn_small");
    private readonly By _title = By.CssSelector(".title");
    
    public HeaderSection Header => new (_driver);
    
    public bool IsCartIconDisplayed()
    {
        return _driver.FindElement(_shoppingCart)?.Displayed ?? false; //Если элемент существует, проверяем Displayed. Если результат оказался null, используем false.
    }

    public ProductPage AddToCart()
    {
        _driver.FindElement(_addToCart).Click();
        return this;
    }

    public int GetCartCounter()
    {
        return int.Parse(_driver.FindElement(_shoppingCartCounter).Text);
    }

    public bool IsTitleDisplayed()
    {
        return _driver.FindElement(_title).Displayed;
    }

    public CartPage OpenCart()
    {
        _driver.FindElement(_shoppingCart).Click();
        return new CartPage(_driver);
    }
    
    public bool ProductsHaveRequiredElements()
    {
        var products = _driver.FindElements(
            By.CssSelector("[data-test='inventory-item']"));

        foreach (var product in products)
        {
            if (!product.FindElement(By.ClassName("inventory_item_img")).Displayed)
                return false;

            if (!product.FindElement(By.ClassName("inventory_item_name")).Displayed)
                return false;

            if (!product.FindElement(By.ClassName("inventory_item_desc")).Displayed)
                return false;

            if (!product.FindElement(By.ClassName("inventory_item_price")).Displayed)
                return false;

            if (!product.FindElement(By.TagName("button")).Displayed)
                return false;
        }

        return true;
    }
}