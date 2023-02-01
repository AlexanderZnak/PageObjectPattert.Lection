using NUnit.Allure.Attributes;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectPattert.Lection.Configurations;
using Logger = PageObjectPattert.Lection.Utilities.Logger;

namespace PageObjectPattert.Lection.Pages;

public abstract class BasePage
{
    protected IWebDriver WebDriver { get; }

    protected BasePage(IWebDriver webDriver)
    {
        WebDriver = webDriver;
    }

    protected IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);

    protected abstract By UniqueWebLocator { get; }

    private readonly string _baseUrl = AppConfiguration.Url;

    protected abstract string UrlPath { get; }

    [AllureStep("Open page")]
    public void OpenPage()
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        Logger.Instance.Info(uri.ToString());
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
            var errorMessage = $"Page with unique locator: '{UniqueWebLocator}' was not opened";
            Logger.Instance.Fatal(errorMessage);
            throw new AssertionException(errorMessage, e);
        }
    }
}