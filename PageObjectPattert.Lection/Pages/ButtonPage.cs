using OpenQA.Selenium;

namespace PageObjectPattert.Lection.Pages;

public class ButtonPage : BasePage
{
    public ButtonPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator =>
        By.XPath("//*[contains(@class, \"entry-title\") and contains(text(),\"Button\")]");

    protected override string UrlPath => "/button/";
}