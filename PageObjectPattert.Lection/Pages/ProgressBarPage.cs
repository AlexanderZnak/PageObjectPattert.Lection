using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectPattert.Lection.Conditions;
using PageObjectPattert.Lection.Configurations;
using PageObjectPattert.Lection.Locators;

namespace PageObjectPattert.Lection.Pages;

public class ProgressBarPage : BasePage
{
    public ProgressBarPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator =>
        By.XPath("//*[contains(@class, \"entry-title\") and contains(text(),\"Progressbar\")]");

    protected override string UrlPath => "/progressbar/#download";

    private bool IsInModalFormIFrame { get; set; }

    private IWebElement ModalFormIFrame => WebDriver.FindElement(DialogPageLocators.ModalFormIFrameLocator);

    private IWebElement StartDownloadButton =>
        WebDriverWait.Until(driver => driver.FindElement(By.CssSelector("#downloadButton")));

    private IWebElement FileDownloadProgressCompleteLabel =>
        WebDriver.FindElement(By.XPath("//*[(@class=\"progress-label\" and text()=\"Complete!\")]"));

    public bool IsDownloadFileProgressComplete(TimeSpan? timeout = null)
    {
        var conditionTimeout = timeout == null ? TimeSpan.FromSeconds(AppConfiguration.ConditionTimeout) : timeout;
        
        FluentWait.PollingInterval = TimeSpan.FromMilliseconds(1);
        FluentWait.Timeout = conditionTimeout.Value;

        var isDownloadFileProgressComplete = FluentWait.Until(driver =>
            {
                return driver.FindElement(By.XPath("//*[(@class=\"progress-label\" and text()=\"Complete!\")]"))
                    .Displayed;
            }
        );
        return isDownloadFileProgressComplete;
    }

    private void BreakInToModalFormIFrame()
    {
        if (IsInModalFormIFrame)
        {
            return;
        }

        WebDriver.SwitchTo().Frame(ModalFormIFrame);
        IsInModalFormIFrame = true;
    }

    public void ClickStartDownloadButton()
    {
        BreakInToModalFormIFrame();
        StartDownloadButton.Click();
        SafeWaitForPageLoadViaJs();
    }

    public void CreateAlert()
    {
        JavaScriptExecutor.ExecuteScript("alert(\"Hello World\")");
    }

    public string GetAlertText()
    {
        IAlert alert = WebDriver.SwitchTo().Alert();
        return alert.Text;
    }
    
    public void ClickStartDownloadButtonViaJs()
    {
        BreakInToModalFormIFrame();
        JavaScriptExecutor.ExecuteScript("arguments[0].click();", StartDownloadButton);
        SafeWaitForPageLoadViaJs();
    }

    public void ConfirmAlert()
    {
        IAlert alert = WebDriver.SwitchTo().Alert();
        alert.Accept();
    }
}