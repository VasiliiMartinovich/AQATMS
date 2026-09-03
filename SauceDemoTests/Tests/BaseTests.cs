using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

public class BaseTests
{
    protected IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--guest"); 
        driver = new ChromeDriver(options);
        new BasePage(driver).OpenSauceDemo();
    }
    [TearDown]
    public void CloseBrowser()
    {
        driver.Quit();
        driver.Dispose();
    }
}