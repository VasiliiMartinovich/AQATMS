using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SauceDemoTests.Pages;

public class OverviewPage : LoadablePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(OverviewPage));
    // private readonly Button _btnFinish;
    // private readonly Label _txtSuccess;
    
    [FindsBy(How = How.Id, Using = "finish")]
    private IWebElement _btnFinish;
    
    [FindsBy(How = How.XPath, Using = "//h2[text()='Thank you for your order!']")]
    private IWebElement _txtSuccess;
    
    public OverviewPage(IWebDriver driver) : base(driver)
    {
        // _btnFinish = new Button(driver, By.Id("finish"));
        // _txtSuccess = new Label(driver, By.XPath("//h2[text()='Thank you for your order!']"));
        PageFactory.InitElements(driver, this);
    }

  public override bool IsLoaded()
    {
        logger.Info("Checking that Overview page is loaded");
        WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        return Wait.Until(driver => _btnFinish.Displayed);
    }
    public bool IsFinishButtonDisplayed()
    {
        logger.Info("Checking if Overview page displays");
        return _btnFinish.Displayed;
    }
    
    public void ClickFinishButton()
    {
        _btnFinish.Click();
    }
    
    public bool IsSuccessMessageDisplayed()
    {
        logger.Info("Checking if order is completed");
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => _txtSuccess.Displayed);
        return _txtSuccess.Displayed;
    }
}