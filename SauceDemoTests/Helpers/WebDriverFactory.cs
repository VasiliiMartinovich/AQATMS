using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using SauceDemoTests.Models;

namespace SauceDemoTests.Helpers;

public static class WebDriverFactory
{
    public static IWebDriver Create(Browser browser)
    {
        return browser switch
        {
            Browser.Chrome => CreateChrome(),
            Browser.Firefox => CreateFirefox(),
            Browser.Safari => CreateSafari(),
            _ => throw new ArgumentOutOfRangeException(nameof(browser), browser, "Unsupported browser")
        };
    }

    private static IWebDriver CreateChrome()
    {
        var options = new ChromeOptions();

        options.AddArgument("--headless=new");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--disable-gpu");

        options.AddArgument("--guest");

        return new ChromeDriver(options);
    }
        
        private static IWebDriver CreateFirefox()
        {
            var options = new FirefoxOptions();
            return new FirefoxDriver(options);
        }
        
        private static IWebDriver CreateSafari()
        {
            var options = new SafariOptions();
            return new SafariDriver(options);
        }
}
