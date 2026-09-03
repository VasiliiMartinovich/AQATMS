using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace HerokuApp.Pages;

public class NestedFramesPage
{
    protected IWebDriver _driver;
    public NestedFramesPage(IWebDriver driver)
    {
        _driver = driver;
    }
    public void Open()
    {
        _driver.Navigate().GoToUrl("https://demoqa.com/nestedframes");
        _driver.Manage().Window.Maximize();
    }
    
    private readonly By _parentFrame = By.Id("frame1");
    private readonly By _childFrame = By.XPath("//iframe");
    private readonly By _body = By.TagName("body");
    public void SwitchToParentFrame()
    {
        _driver.SwitchTo().Frame("frame1");
    }
    public void SwitchToChildFrame()
    {
        _driver.SwitchTo().Frame(1);
    }
    public string GetFrameText()
    {
        return _driver.FindElement(_body).Text;
    }
}