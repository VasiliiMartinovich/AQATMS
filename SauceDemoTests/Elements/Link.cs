using OpenQA.Selenium;

namespace SauceDemoTests.Elements;

public class Link : BaseElement
{
    public Link(IWebDriver driver, By locator) : base(driver, locator)
    {
    }

    public void Click()
    {
        FindElement().Click();
    }
}