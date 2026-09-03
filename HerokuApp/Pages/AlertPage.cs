using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HerokuApp.Pages;

public class AlertPage
{
    protected IWebDriver _driver;

    public AlertPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public void Open()
    {
        _driver.Navigate().GoToUrl("https://demoqa.com/alerts");
        _driver.Manage().Window.Maximize();
    }
    
    private readonly By _alertButton = By.Id("alertButton");
    private readonly By _timerAlertButton = By.Id("timerAlertButton");
    private readonly By _confirmButton = By.Id("confirmButton");
    private readonly By _promptButton = By.Id("promtButton");
    
    public void ClickAlertButton()
    {
        _driver.FindElement(_alertButton).Click();
    }
    
    public string GetAlertText()
    {
        return _driver.SwitchTo().Alert().Text;
    }
    public void AcceptAlert()
    {
        _driver.SwitchTo().Alert().Accept();
    }
    public void ClickAlertTimer()
    {
        _driver.FindElement(_timerAlertButton).Click();
    }
    public void WaitForAlert()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        wait.Until(driver => driver.FindElement(_timerAlertButton).Text == "This alert appeared after 5 seconds");
    }
    
    public void ClickAlertConfirm()
    {
        _driver.FindElement(_confirmButton).Click();
    }
    public void DismissAlert()
    {
        _driver.SwitchTo().Alert().Dismiss();
    }
    public void ClickAlertPrompt()
    {
        _driver.FindElement(_promptButton).Click();
    }
    
    public void SendValueAlert(string message)
    {
        _driver.SwitchTo().Alert().SendKeys(message);
    }
}