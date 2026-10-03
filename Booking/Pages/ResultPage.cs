using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Booking.Pages;

public class ResultPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    
    private readonly By _hotelName = By.CssSelector("[data-testid='title']");
    private readonly By _hotelCard = By.CssSelector("[data-testid='property-card']");
    private readonly By _rating = By.CssSelector("[data-testid='review-score'] > div[aria-hidden='true']");
    
    public ResultPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }
    public bool IsHotelCardsDisplayed(string hotelName)
    {
        GetHotelCard(hotelName);
        return true;
    }

    public string GetHotelRating(string hotelName)
    {
        var hotel = GetHotelCard(hotelName);
        var ratingElement = hotel.FindElement(_rating);

        return ratingElement.Text.Trim();
    }

    private IWebElement GetHotelCard(string hotelName)
    {
        return _wait.Until(driver =>
        {
            var hotels = driver.FindElements(_hotelCard);
            foreach (var hotel in hotels)
            {
                try
                {
                    if (!hotel.Displayed)
                        continue;
                    var name = hotel.FindElement(_hotelName);
                    if (name.Text.Equals(hotelName, StringComparison.OrdinalIgnoreCase))
                    {
                        return hotel;
                    }
                }
                catch (StaleElementReferenceException)
                {
                }
            }
            return null;
        });
    }
    public bool HasExpectedRating(string hotelName, string expectedRating)
    {
        string actualRating = GetHotelRating(hotelName);
        return actualRating == expectedRating;
    }
}