using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace HerokuApp.Pages;

public class JSTests
{
    protected IWebDriver driver;
    private MainPage _mainPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        driver.Manage().Window.Maximize();
        _mainPage = new MainPage(driver);
    }
    
    [Test]
    public void JSScrollTest()
    {
        MainPage mainPage = new MainPage(driver);
        mainPage.ScrollToBottom();
        Thread.Sleep(3000);
    }
    
    [Test]
    public void JSGenerateALert()
    {
        MainPage mainPage = new MainPage(driver);
        mainPage.GenerateALert();
        mainPage.GetAlertText();
        Assert.That(mainPage.GetAlertText(), Is.EqualTo("JS alert test!!!"));
        mainPage.AcceptAlert();
    }

    [Test]
    public void GetTitleOfPage()
    {
        var title = _mainPage.GetTitle();
        Assert.That(title, Is.EqualTo("The Internet"));
    }
    
    [Test]
    public void PageReload()
    {
        MainPage mainPage = new MainPage(driver);
        Thread.Sleep(3000);
        mainPage.PageReload();
        Thread.Sleep(3000);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}