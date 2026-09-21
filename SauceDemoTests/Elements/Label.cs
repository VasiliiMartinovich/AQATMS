using OpenQA.Selenium;

namespace SauceDemoTests.Elements;

public class Label : BaseElement
{
    public Label(IWebDriver driver, By locator) : base(driver, locator)
    {
    }

    public string GetText()
    {
        return FindElement().Text;
    }
}