using OpenQA.Selenium;
using Reqnroll;


namespace Booking.Pages;

[Binding]
public class BookingSearchSteps
{
    private readonly ScenarioContext _scenarioContext;

    private MainPage _mainPage = null!;
    private ResultPage _resultsPage = null!;

    public BookingSearchSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("I open Booking.com")]
    public void GivenIOpenBookingCom()
    {
        IWebDriver driver = _scenarioContext.Get<IWebDriver>();
        _mainPage = new MainPage(driver);
        _mainPage.Open();
        Thread.Sleep(2000);
    }

    [When("I search for hotel \"(.*)\"")]
    public void WhenISearchForHotel(string hotelName)
    {
        _resultsPage = _mainPage.SearchForHotel(hotelName);
    }

    [Then("hotel \"(.*)\" should be displayed in search results")]
    public void ThenHotelShouldBeDisplayed(string hotelName)
    {
        Assert.That(_resultsPage.IsHotelCardsDisplayed(hotelName), Is.True, $"Hotel '{hotelName}' was not found.");
    }

    [Then("hotel \"(.*)\" should have rating \"(.*)\"")]
    public void ThenHotelShouldHaveRating(string hotelName, string expectedRating)
    {
        Assert.That(_resultsPage.HasExpectedRating(hotelName, expectedRating), Is.True, $"Hotel '{hotelName}' does not have rating '{expectedRating}'.");
    }
}