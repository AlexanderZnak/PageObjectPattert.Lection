using OpenQA.Selenium;
using PageObjectPattert.Lection.DriverConfiguration;
using PageObjectPattert.Lection.Pages;

namespace PageObjectPattert.Lection.Tests;

public abstract class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }
    
    protected DialogPage DialogPage { get; private set; }
    
    protected HomePage HomePage { get; private set; }
    
    protected ProgressBarPage ProgressBarPage { get; private set; }
    
    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        
        DialogPage = new DialogPage(WebDriver);
        HomePage = new HomePage(WebDriver);
        ProgressBarPage = new ProgressBarPage(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}