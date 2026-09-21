using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.Elements;

public class BaseElement
{
    protected readonly IWebDriver _driver;
    protected readonly By _locator;
    protected readonly WebDriverWait _wait;

    public BaseElement(IWebDriver driver, By locator)
    {
        _driver = driver;
        _locator = locator;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }
    protected IWebElement FindElement()
    {
        return _driver.FindElement(_locator);
    }

    public bool IsDisplayed()
    {
        return FindElement().Displayed;
    }
    
    public string GetText()
    {
        return FindElement().Text;
    }

    public void WaitUntilDisplayed()
    {
        _wait.Until(driver =>
        {
            try
            {
                return driver.FindElement(_locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        });
    }
}