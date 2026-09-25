using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.Pages;

public abstract class LoadablePage : BasePage
{
    protected readonly WebDriverWait _wait;

    protected LoadablePage(IWebDriver driver) : base(driver)
    {
       this._driver =  driver;
    }

    public abstract bool IsLoaded();
    
}