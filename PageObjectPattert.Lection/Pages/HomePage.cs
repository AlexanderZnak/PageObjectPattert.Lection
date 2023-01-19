using OpenQA.Selenium;

namespace PageObjectPattert.Lection.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => By.CssSelector(".download-box");

    protected override string UrlPath => string.Empty;

    private readonly By _leftMenuDialogIconLocator =
        By.XPath("//*[@class=\"widget\"]//*[text()=\"Dialog\"]");

    private IWebElement LeftMenuDialogIcon => WebDriver.FindElement(_leftMenuDialogIconLocator);

    public void ClickLeftMenuDialogIcon()
    {
        LeftMenuDialogIcon.Click();

        // if you do not want to use all time assertions
        new DialogPage(WebDriver).WaitForPageLoad();
    }
}