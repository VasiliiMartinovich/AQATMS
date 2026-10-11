using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace Booking.Pages;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        _scenarioContext.Set(driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        IWebDriver driver = _scenarioContext.Get<IWebDriver>();
        driver.Quit();
        driver.Dispose();
    }
}