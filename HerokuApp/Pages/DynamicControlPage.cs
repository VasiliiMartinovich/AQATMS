using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HerokuApp.Pages;

public class DynamicControlsPage
{
    protected IWebDriver _driver;

    public DynamicControlsPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void Open()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
        _driver.Manage().Window.Maximize();
    }

    private readonly By _checkbox = By.Id("checkbox");
    private readonly By _btnRemove = By.XPath("//button[text()='Remove']");
    private readonly By _message = By.Id("message");
    private readonly By _inputField = By.XPath("//input[@type='text']");
    private readonly By _inputButton = By.CssSelector("[onclick='swapInput()']");
    private readonly By _inputText = By.XPath("//p[@id='message' and text()=\"It's enabled!\"]");

    public bool CheckboxIsDisplayed()
    {
        return _driver.FindElements(_checkbox).Count > 0;
    }

    public DynamicControlsPage RemoveCheckbox()
    {
        _driver.FindElement(_btnRemove).Click();
        return this;
    }
    public void WaitForMessageOne()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.FindElement(_message).Text == "It's gone!");
    }
    public bool CheckInput()
    {
        return _driver.FindElement(_inputField).Enabled;
    }

    public void InputState()
    {
        _driver.FindElement(_inputButton).Click();
    }
    public void WaitForMessageTwo()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver =>
            driver.FindElement(_inputText).Text == "It's enabled!"
        );
    }
    
}