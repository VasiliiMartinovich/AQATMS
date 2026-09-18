using Allure.Net.Commons;
using log4net;
using log4net.Config;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

public class BaseTests
{
    protected IWebDriver driver = null;
    private ILog logger = LogManager.GetLogger(typeof(BaseTests));
    
    public BaseTests()
    {
        var configFile = new FileInfo("TestData/log4net.config");
        XmlConfigurator.Configure(configFile);
    }

    [SetUp]
    public void Setup()
    {
        Console.WriteLine("BaseSetup");
        logger.Info("Test setup started");
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--guest"); 
        driver = new ChromeDriver(options);
        logger.Info("Chrome browser started");
        driver.Manage().Window.Maximize();
        logger.Info("maximizing Chrome Window");
        AllureApi.Step("Open Sauce Demo.", () =>
        {
            new BasePage(driver).OpenSauceDemo();
            logger.Info("Open Sauce Demo.");
        });
    }
    
    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("BaseTeardown");

        try
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed && driver != null)
            {
                logger.Error("Test Failed: " + TestContext.CurrentContext.Result.Message);
                byte[] screenshotBytes =
                    ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;

                AllureApi.AddAttachment(
                    "Screenshot",
                    "image/png",
                    screenshotBytes);
            }
        }
        finally
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
