using OpenQA.Selenium;

namespace SauceDemoTests.Elements;

public class CartItem
{
    private readonly IWebElement _cartItem;

    private readonly By _quantity = By.ClassName("cart_quantity");
    private readonly By _label = By.ClassName("cart_item_label");
    private readonly By _description = By.ClassName("inventory_item_desc");
    private readonly By _priceBar = By.ClassName("item_pricebar");
    private readonly By _removeButton = By.CssSelector(".btn.btn_secondary.btn_small");

    public CartItem(IWebElement cartItem)
    {
        _cartItem = cartItem;
    }

    public bool IsQuantityDisplayed()
    {
        return _cartItem.FindElement(_quantity).Displayed;
    }

    public bool IsLabelDisplayed()
    {
        return _cartItem.FindElement(_label).Displayed;
    }

    public bool IsDescriptionDisplayed()
    {
        return _cartItem.FindElement(_description).Displayed;
    }

    public bool IsPriceBarDisplayed()
    {
        return _cartItem.FindElement(_priceBar).Displayed;
    }

    public bool IsRemoveButtonDisplayed()
    {
        return _cartItem.FindElement(_removeButton).Displayed;
    }

    public bool HasRequiredElements()
    {
        return IsQuantityDisplayed()
               && IsLabelDisplayed()
               && IsDescriptionDisplayed()
               && IsPriceBarDisplayed()
               && IsRemoveButtonDisplayed();
    }
}