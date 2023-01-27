using OpenQA.Selenium;
using PageObjectPattert.Lection.DriverConfiguration;
using PageObjectPattert.Lection.Pages;

namespace PageObjectPattert.Lection.Tests;

public abstract class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }
    
    protected DialogPage DialogPage { get; private set; }
    
    protected HomePage HomePage { get; private set; }
    
    protected SelectmenuPage SelectmenuPage { get; private set; }
    
    protected DraggablePage DraggablePage { get; private set; }
    
    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        
        DialogPage = new DialogPage(WebDriver);
        HomePage = new HomePage(WebDriver);
        SelectmenuPage = new SelectmenuPage(WebDriver);
        DraggablePage = new DraggablePage(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}