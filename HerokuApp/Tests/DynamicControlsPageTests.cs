using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using HerokuApp.Pages;

namespace HerokuApp;

public class Tests
{
    protected IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void DynamicControls()
    {
        DynamicControlsPage dynamicControlsPage = new DynamicControlsPage(driver);
        Assert.That(dynamicControlsPage.CheckboxIsDisplayed(), Is.True);
        dynamicControlsPage.RemoveCheckbox();
        dynamicControlsPage.WaitForMessageOne();
        Assert.That(dynamicControlsPage.CheckboxIsDisplayed(), Is.False);
        Assert.That(dynamicControlsPage.CheckInput(), Is.False);
        dynamicControlsPage.InputState();
        dynamicControlsPage.WaitForMessageTwo();
        Assert.That(dynamicControlsPage.CheckInput(), Is.True);
    }
    
    [TearDown]
    public void CloseBrowser()
    {
        driver.Quit();
        driver.Dispose();
    }
    
}