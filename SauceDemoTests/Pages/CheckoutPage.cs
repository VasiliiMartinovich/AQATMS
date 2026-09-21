using log4net;
using OpenQA.Selenium;
using SauceDemoTests.Elements;

namespace SauceDemoTests.Pages;

public class CheckoutPage : BasePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(LoginPage));
    private readonly TextField _firstName;
    private readonly TextField _lastName;
    private readonly TextField _zipcode;
    private readonly Button _continueButton;
    public CheckoutPage(IWebDriver driver) : base(driver)
    {
        _firstName = new TextField(driver, By.Id("first-name"));
        _lastName = new TextField(driver, By.Id("last-name"));
        _zipcode = new TextField(driver, By.Id("postal-code"));
        _continueButton = new Button(driver, By.CssSelector("[data-test='continue']"));
    }
    
   public bool IsCheckoutPageDisplayed() =>
        _firstName.IsDisplayed()
        && _lastName.IsDisplayed()
        && _zipcode.IsDisplayed()
        && _continueButton.IsDisplayed();
    public CheckoutPage SetFirstName(string firstname, string lastname,string zipcode)
    {
        logger.Info("Adding an item to the cart");
        _firstName.SetValue(firstname);
        return this;
    }
    
    public CheckoutPage SetLastName(string lastname)
    {
        _lastName.SetValue(lastname);
        return this;
    }
    
    public CheckoutPage SetZipcode(string zipcode)
    {
        _zipcode.SetValue(zipcode);
        return this;
    }
    
    public CheckoutPage SetCustomerInformation(string firstname, string lastname, string zipcode)
    {
        logger.Info("Entering customer information");
        _firstName.SetValue(firstname);
        _lastName.SetValue(lastname);
        _zipcode.SetValue(zipcode);
        return this;
    }
    
    public OverviewPage ClickContinueButton()
    {
        _continueButton.Click();
        return new OverviewPage (_driver);
    }
}