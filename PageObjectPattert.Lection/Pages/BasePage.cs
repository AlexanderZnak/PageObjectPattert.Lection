using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectPattert.Lection.Configurations;
using PageObjectPattert.Lection.Utilities;

namespace PageObjectPattert.Lection.Pages;

public abstract class BasePage
{
    protected IWebDriver WebDriver { get; }

    protected WebDriverWait WebDriverWait { get; }

    protected DefaultWait<IWebDriver> FluentWait { get; }
    
    protected IJavaScriptExecutor JavaScriptExecutor { get; }

    protected BasePage(IWebDriver webDriver)
    {
        WebDriver = webDriver;
        WebDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(AppConfiguration.ConditionTimeout));
        FluentWait = new DefaultWait<IWebDriver>(WebDriver);
        JavaScriptExecutor = (IJavaScriptExecutor)WebDriver;
    }

    protected IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);

    protected abstract By UniqueWebLocator { get; }

    private readonly string _baseUrl = AppConfiguration.Url;

    protected abstract string UrlPath { get; }

    public void OpenPage()
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        WebDriver.Navigate().GoToUrl(uri);
        WaitForPageLoad();
    }

    public bool IsPageOpened
    {
        get
        {
            bool isOpened;
            try
            {
                isOpened = UniqueWebElement.Displayed;
            }
            catch (Exception e)
            {
                isOpened = false;
            }

            return isOpened;
        }
    }

    public void WaitForPageLoad()
    {
        var driverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3));

        try
        {
            driverWait.Until(driver => driver.FindElement(UniqueWebLocator).Displayed);
        }
        catch (WebDriverTimeoutException e)
        {
            throw new AssertionException($"Page with unique locator: '{UniqueWebLocator}' was not opened", e);
        }
    }

    protected void SafeWaitForPageLoadViaJs()
    {
        FluentWait.Timeout = TimeSpan.FromSeconds(20);
        FluentWait.PollingInterval = TimeSpan.FromSeconds(2);

        FluentWait.Until(d =>
        {
            var result = JavaScriptExecutor.ExecuteScript("return document.readyState");
            return result.Equals("complete");
        });
    }
}