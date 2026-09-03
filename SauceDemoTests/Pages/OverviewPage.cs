using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.Pages;

public class OverviewPage : BasePage
{
    public OverviewPage(IWebDriver driver) : base(driver)
    {
    }

    private readonly By _btnFinish = By.Id("finish");
    private readonly By _txtSuccess = By.XPath("//h2[text()='Thank you for your order!']");

    public bool IsFinishButtonDisplayed()
    {
        return _driver.FindElement(_btnFinish).Displayed;
    }
    
    public void ClickFinishButton()
    {
        _driver.FindElement(_btnFinish).Click();
    }
    
    public bool IsSuccessMessageDisplayed()
    {
        return _driver.FindElements(_txtSuccess)
            .Count == 1;
    }
}