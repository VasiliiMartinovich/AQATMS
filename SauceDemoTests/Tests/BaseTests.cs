using Allure.Net.Commons;
using log4net;
using log4net.Config;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SauceDemoTests.Helpers;
using SauceDemoTests.Models;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

public class BaseTests
{
    protected IWebDriver driver = null!;
    protected TestSettings settings = null!;
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
        settings = ConfigurationReader.GetSettings();
        driver = WebDriverFactory.Create(settings.Browser);
        logger.Info("Browser started");
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
