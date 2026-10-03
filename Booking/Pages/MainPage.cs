using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Booking.Pages;

public class MainPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    
    private readonly By _searchField = By.Id("searchbox-horizontal-destination-input");
    private readonly By _searchButton = By.CssSelector("button[type=submit]");
    private readonly By _searchSuggestions = By.CssSelector("li[role='option']");
    
    public MainPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }
    public void Open()
    {
        _driver.Navigate().GoToUrl("https://www.booking.com/searchresults.en-gb.html");
        AcceptCookies();
        CloseSignInPopup();
    }

    public void EnterHotelName(string hotelName)
    {
        IWebElement searchField = _wait.Until(driver => driver.FindElement(_searchField));
        searchField.Clear();
        searchField.SendKeys(hotelName);
    }
    
    public void SelectHotelSuggestion(string hotelName)
    {
        var suggestion = _wait.Until(driver =>
        {
            var suggestions = driver.FindElements(_searchSuggestions);

            return suggestions.FirstOrDefault(s => s.Displayed && s.Text.Contains(hotelName, StringComparison.OrdinalIgnoreCase));
        });
        suggestion.Click();
    }
   
    public ResultPage ClickSearch()
    {
        IWebElement searchButton = _wait.Until(driver => driver.FindElement(_searchButton));
        searchButton.Click();
        return new ResultPage(_driver);
    }

    public ResultPage SearchForHotel(string hotelName)
    {
        EnterHotelName(hotelName);
        SelectHotelSuggestion(hotelName);
        return ClickSearch();
    }
    
    private void AcceptCookies()
    {
        try
        {
            var shortWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            shortWait.Until(d => d.FindElement(By.Id("onetrust-accept-btn-handler"))).Click();
        }
        catch (WebDriverTimeoutException) {}
    }
    
    private void CloseSignInPopup()
    {
        try
        {
            var shortWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            shortWait.Until(d => d.FindElement(By.CssSelector("button[aria-label='Dismiss sign-in info.']"))).Click();
        }
        catch (WebDriverTimeoutException) {}
    }
}