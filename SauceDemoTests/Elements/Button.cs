using OpenQA.Selenium;

namespace SauceDemoTests.Elements;

public class Button : BaseElement
{
    public Button(IWebDriver driver, By locator) : base(driver, locator)
    {
    }
    
    public void Click()
    {
        FindElement().Click();
    }
}