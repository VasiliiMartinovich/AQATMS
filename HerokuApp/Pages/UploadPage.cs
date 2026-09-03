using OpenQA.Selenium;

namespace HerokuApp.Pages;
    
public class UploadPage
{
    private  IWebDriver _driver;
    public UploadPage(IWebDriver driver)
    {
        _driver = driver;
    }
    private readonly By _upload = By.CssSelector("input[type='file']");
    private readonly By _uploadedFile = By.Id("uploadedFilePath");
    private readonly By _downloadBtn = By.Id("downloadButton");
    public void Open()
    {
        _driver.Navigate().GoToUrl("https://demoqa.com/upload-download");
    }
    public void UploadFile(string filePath)
    {
        _driver.FindElement(_upload).SendKeys(filePath);
    }
    public string GetUploadedFileName()
    {
        string fileName = _driver.FindElement(_uploadedFile).Text;
        return Path.GetFileName(fileName);
    }
    public void DownloadFile()
    {
        _driver.FindElement(_downloadBtn).Click();
    }
}