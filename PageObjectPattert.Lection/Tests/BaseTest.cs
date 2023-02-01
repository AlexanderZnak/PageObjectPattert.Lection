using Allure.Net.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using PageObjectPattert.Lection.DriverConfiguration;
using PageObjectPattert.Lection.Pages;

namespace PageObjectPattert.Lection.Tests;

public abstract class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }

    protected DialogPage DialogPage { get; private set; }

    protected HomePage HomePage { get; private set; }

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        DialogPage = new DialogPage(WebDriver);
        HomePage = new HomePage(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;

        if (status == TestStatus.Failed)
        {
            var webDriver = (WebDriver)WebDriver;
            var screenshot = webDriver.GetScreenshot();
            var fileName = TestContext.CurrentContext.Test.Name + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".png";
            var path = Path.Combine(AppContext.BaseDirectory, "Resources", fileName);
            screenshot.SaveAsFile(path);

            AllureLifecycle.Instance.AddAttachment(path);
        }

        WebDriver.Quit();
    }
}