using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
namespace HerokuApp.Pages;
public class ActionsTests
{
    protected IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://demoqa.com/droppable");
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void DragAndDropTest()
    {
        DropPage dropPage = new DropPage(driver);
        dropPage.DragAndDrop();
        dropPage.WaitForMsg();
        Assert.That(dropPage.GetDropText(), Is.EqualTo("Dropped!"));
    }
        
    [TearDown]
    public void CloseBrowser()
    {
        driver.Quit();
        driver.Dispose();
    }
}