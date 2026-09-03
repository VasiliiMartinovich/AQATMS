using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuApp.Pages;

public class UploadTests
{
    protected IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://demoqa.com/upload-download");
        driver.Manage().Window.Maximize();
    }
    
    [Test]
    public void FileUploadTest()
    {
        string filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "TestData",
            "UploadFile.txt"
        );
        Assert.That(File.Exists(filePath), Is.True);
        UploadPage uploadPage =  new UploadPage(driver);
        uploadPage.UploadFile(filePath);
        string uploadedFileName =  uploadPage.GetUploadedFileName();
        Assert.That(uploadedFileName, Does.Contain("UploadFile.txt"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}