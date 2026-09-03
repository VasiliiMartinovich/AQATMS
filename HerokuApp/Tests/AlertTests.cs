using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace HerokuApp.Pages;

public class AlertTests
{
    protected IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://demoqa.com/alerts");
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void AlertOne()
    {
        AlertPage alertPage = new AlertPage(driver);
        alertPage.ClickAlertButton();
        Assert.That(alertPage.GetAlertText(), Is.EqualTo("You clicked a button"));
        alertPage.AcceptAlert();
    }
    
    [Test]
    public void AlertTwo()
    {
        AlertPage alertPage = new AlertPage(driver);
        alertPage.ClickAlertTimer();
        Thread.Sleep(6000);
        //alertPage.WaitForAlert();
        Assert.That(alertPage.GetAlertText(), Is.EqualTo("This alert appeared after 5 seconds"));
        alertPage.AcceptAlert();
    }
    
    [Test]
    public void AlertThree()
    {
        AlertPage alertPage = new AlertPage(driver);
        alertPage.ClickAlertConfirm();
        Thread.Sleep(2000);
        Assert.That(alertPage.GetAlertText(), Is.EqualTo("Do you confirm action?"));
        alertPage.DismissAlert();
    }
    
    [Test]
    public void AlertFour()
    {
        string prompt = "QA test";
        AlertPage alertPage = new AlertPage(driver);
        alertPage.ClickAlertPrompt();
        Thread.Sleep(2000);
        Assert.That(alertPage.GetAlertText(), Is.EqualTo("Please enter your name"));
        alertPage.SendValueAlert(prompt);
        Thread.Sleep(2000);
        alertPage.AcceptAlert();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}