using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
namespace HerokuApp.Pages;

public class NestedFramesTests
{
    protected IWebDriver driver;
    private NestedFramesPage _nestedFramesPage;
    
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://demoqa.com/nestedframes");
        driver.Manage().Window.Maximize();
        _nestedFramesPage = new NestedFramesPage(driver);
        _nestedFramesPage.Open();
    }

    [Test]
    public void CheckParentFrameText()
    {
        _nestedFramesPage.SwitchToParentFrame();
        var text = _nestedFramesPage.GetFrameText();
        Assert.That(text, Does.Contain("Parent frame"));
    }
    
    [Test]
    public void CheckChildFrameText()
    {
        _nestedFramesPage.SwitchToParentFrame();
        _nestedFramesPage.SwitchToChildFrame();
        var text = _nestedFramesPage.GetFrameText();
        Assert.That(text, Does.Contain("Child Iframe"));
    }
    
    
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}