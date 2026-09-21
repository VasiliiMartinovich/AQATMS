using OpenQA.Selenium;

namespace SauceDemoTests.Elements;

public class TextField : BaseElement
{
    public TextField(IWebDriver driver, By locator) : base(driver, locator)
    {
    }
    
    public void SetValue(string text)
    {
        var element = FindElement();
        element.Clear();
        element.SendKeys(text);
    }
    
    public string GetValue()
    {
        return FindElement().GetAttribute("value") ?? string.Empty;
    }

    public void Clear()
    {
        FindElement().Clear();
    }
}