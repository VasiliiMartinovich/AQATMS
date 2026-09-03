using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace HerokuApp.Pages;

public class DownloadTests
{
    private IWebDriver driver;
    private UploadPage _downloadPage;
    private string _downloadFolder;
    
    [SetUp]
    public void Setup()
    {
        _downloadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Downloads");
        Directory.CreateDirectory(_downloadFolder);
        var options = new ChromeOptions();
        options.AddUserProfilePreference("download.default_directory", _downloadFolder);

        options.AddUserProfilePreference("download.prompt_for_download", false);

        options.AddUserProfilePreference("download.directory_upgrade", true);
        
        driver = new ChromeDriver(options);
        _downloadPage = new UploadPage(driver);
        _downloadPage.Open();
        driver.Manage().Window.Maximize();
    }
    
    [Test]
    public void DownloadFileTest()
    {
        UploadPage uploadPage = new UploadPage(driver);
        uploadPage.DownloadFile();
        Thread.Sleep(2000);
        
        var filePath = Path.Combine(_downloadFolder, "sampleFile.jpeg");

        Assert.That(File.Exists(filePath), Is.True, "Файл не был скачан");
    }
    
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}