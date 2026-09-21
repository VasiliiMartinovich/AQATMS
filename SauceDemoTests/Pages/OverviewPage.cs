using log4net;
using OpenQA.Selenium;
using SauceDemoTests.Elements;

namespace SauceDemoTests.Pages;

public class OverviewPage : BasePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(LoginPage));
    private readonly Button _btnFinish;
    private readonly Label _txtSuccess;
    public OverviewPage(IWebDriver driver) : base(driver)
    {
        _btnFinish = new Button(driver, By.Id("finish"));
        _txtSuccess = new Label(driver, By.XPath("//h2[text()='Thank you for your order!']"));
    }

    public bool IsFinishButtonDisplayed()
    {
        logger.Info("Checking if Overview page displays");
        return _btnFinish.IsDisplayed();
    }
    
    public void ClickFinishButton()
    {
        _btnFinish.Click();
    }
    
    public bool IsSuccessMessageDisplayed()
    {
        logger.Info("Checking if order is completed");
        return _txtSuccess.IsDisplayed();
    }
}