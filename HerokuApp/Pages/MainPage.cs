using OpenQA.Selenium;

namespace HerokuApp.Pages;

public class MainPage
{
    protected IWebDriver _driver;
    public MainPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private readonly By lnkButton = By.LinkText("WYSIWYG Editor");
    
    public void Open()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
    }
    public void ScrollToBottom()
    {
        var btnBottom =  _driver.FindElement(lnkButton);
        var jsExecutor = (IJavaScriptExecutor)_driver;
        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", btnBottom);
    }

    public void GenerateALert()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("alert('JS alert test!!!');");
    }
    
    public string GetAlertText()
    {
        return _driver.SwitchTo().Alert().Text;
    }
    
    public void AcceptAlert()
    {
        _driver.SwitchTo().Alert().Accept();
    }

    public string GetTitle()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        return js.ExecuteScript("return document.title;").ToString();
    }
    
    public void PageReload()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("location.reload()");
    }
}