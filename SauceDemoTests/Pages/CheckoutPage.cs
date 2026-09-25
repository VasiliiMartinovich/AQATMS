using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace SauceDemoTests.Pages;

public class CheckoutPage : LoadablePage
{
    private readonly ILog logger = LogManager.GetLogger(typeof(CheckoutPage));
    // private readonly TextField _firstName;
    // private readonly TextField _lastName;
    // private readonly TextField _zipcode;
    // private readonly Button _continueButton;
    
    [FindsBy(How = How.Id, Using = "first-name")]
    private IWebElement _firstName;
        
    [FindsBy(How = How.Id, Using = "last-name")]
    private IWebElement _lastName;
        
    [FindsBy(How = How.Id, Using = "postal-code")]
    private IWebElement _zipcode;
        
    [FindsBy(How = How.CssSelector, Using = "[data-test='continue']")] 
    private IWebElement _continueButton;

    public CheckoutPage(IWebDriver driver) : base(driver)
    {
        // _firstName = new TextField(driver, By.Id("first-name"));
        // _lastName = new TextField(driver, By.Id("last-name"));
        // _zipcode = new TextField(driver, By.Id("f"));
        // _continueButton = new Button(driver, By.CssSelector("[data-test='continue']"));
        PageFactory.InitElements(driver, this);
    }

    public override bool IsLoaded()
    {
        logger.Info("Checking that Checkout page is loaded");
        WebDriverWait Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        return Wait.Until(driver => _firstName.Displayed);
    }
    
   public bool IsCheckoutPageDisplayed() =>
        _firstName.Displayed
        && _lastName.Displayed
        && _zipcode.Displayed
        && _continueButton.Displayed;
    public CheckoutPage SetFirstName(string firstname)
    {
        logger.Info("Adding an item to the cart");
        _firstName.SendKeys(firstname);
        return this;
    }
    
    public CheckoutPage SetLastName(string lastname)
    {
        _lastName.SendKeys(lastname);
        return this;
    }
    
    public CheckoutPage SetZipcode(string zipcode)
    {
        _zipcode.SendKeys(zipcode);
        return this;
    }
    
    public CheckoutPage SetCustomerInformation(string firstname, string lastname, string zipcode)
    {
        logger.Info("Entering customer information");
        _firstName.SendKeys(firstname);
        _lastName.SendKeys(lastname);
        _zipcode.SendKeys(zipcode);
        return this;
    }
    
    public OverviewPage ClickContinueButton()
    {
        _continueButton.Click();
        return new OverviewPage (_driver);
    }
}
