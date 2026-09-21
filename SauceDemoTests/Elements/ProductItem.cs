using OpenQA.Selenium;

namespace SauceDemoTests.Elements;

public class ProductItem
{
    private readonly IWebElement _product;
    private readonly By _image = By.ClassName("inventory_item_img");
    private readonly By _name = By.ClassName("inventory_item_name");
    private readonly By _description = By.ClassName("inventory_item_desc");
    private readonly By _price = By.ClassName("inventory_item_price");
    private readonly By _button = By.TagName("button");

    public ProductItem(IWebElement product)
    {
        _product = product;
    }

    public bool IsImageDisplayed()
    {
        return _product.FindElement(_image).Displayed;
    }

    public bool IsNameDisplayed()
    {
        return _product.FindElement(_name).Displayed;
    }

    public bool IsDescriptionDisplayed()
    {
        return _product.FindElement(_description).Displayed;
    }

    public bool IsPriceDisplayed()
    {
        return _product.FindElement(_price).Displayed;
    }

    public bool IsButtonDisplayed()
    {
        return _product.FindElement(_button).Displayed;
    }

    public bool HasRequiredElements()
    {
        return IsImageDisplayed()
               && IsNameDisplayed()
               && IsDescriptionDisplayed()
               && IsPriceDisplayed()
               && IsButtonDisplayed();
    }
}