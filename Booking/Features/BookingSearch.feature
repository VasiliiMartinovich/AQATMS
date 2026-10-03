Feature: Booking hotel search

As a user
I want to search for a hotel
So that I can verify that the required hotel is displayed with the expected rating

Scenario Outline: Search for a hotel and verify its rating
    Given I open Booking.com
    When I search for hotel "<hotelName>"
    Then hotel "<hotelName>" should be displayed in search results
    And hotel "<hotelName>" should have rating "<rating>"

Examples:
    | hotelName                                                 | rating |
    | Sahara Dormitory Stay-near NESCO Bombay Exhibition Centre | 6.9    |
    | Townhouse MIDC Andheri Formerly Royal International       | 5.5    |