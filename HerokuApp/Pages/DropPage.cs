using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace HerokuApp.Pages;

public class DropPage
{
    protected static IWebDriver _driver;
    
    public DropPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    public void Open()
    {
        _driver.Navigate().GoToUrl("https://demoqa.com/droppable");
    }
    
    private readonly By _dragMe = By.Id("draggable");
    private readonly By _dropHere = By.Id("droppable");
    
    public void DragAndDrop()
    {
        var source = _driver.FindElement(_dragMe);
        var target = _driver.FindElement(_dropHere);

        Actions actions = new Actions(_driver);

        actions.DragAndDrop(source, target).Perform();
    }
   
    public void WaitForMsg()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        wait.Until(driver => driver.FindElement(_dropHere).Text == "Dropped!"
        );
    }
   
    public string GetDropText()
    {
        return _driver.FindElement(_dropHere).Text;
    }
}