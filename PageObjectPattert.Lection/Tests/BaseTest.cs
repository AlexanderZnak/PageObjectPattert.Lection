using OpenQA.Selenium;
using PageObjectPattert.Lection.DriverConfiguration;
using PageObjectPattert.Lection.Pages;
using PageObjectPattert.Lection.Steps;

namespace PageObjectPattert.Lection.Tests;

public abstract class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }

    protected DialogPage DialogPage { get; private set; }

    protected HomePage HomePage { get; private set; }
    
    protected ButtonPage ButtonPage { get; private set; }
    
    protected DialogPageSteps DialogPageSteps { get; private set; }

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        DialogPage = new DialogPage(WebDriver);
        HomePage = new HomePage(WebDriver);
        ButtonPage = new ButtonPage(WebDriver);
        DialogPageSteps = new DialogPageSteps(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}