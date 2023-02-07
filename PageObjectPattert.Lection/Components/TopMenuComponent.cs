using OpenQA.Selenium;

namespace PageObjectPattert.Lection.Components;

public class TopMenuComponent
{
    protected IWebDriver WebDriver { get; }

    public TopMenuComponent(IWebDriver webDriver)
    {
        WebDriver = webDriver;
    }

    private IWebElement DemosTopMenuIcon =>
        WebDriver.FindElement(By.XPath("//*[contains(@class, \"menu-item\")]//a[contains(text(),\"Demos\")]"));

    private IWebElement DownloadTopMenuIcon =>
        WebDriver.FindElement(By.XPath("//*[contains(@class, \"menu-item\")]//a[contains(text(),\"Download\")]"));

    public void ClickDemosTopMenuIcon()
    {
        DemosTopMenuIcon.Click();
    }

    public void ClickDownloadTopMenuIcon()
    {
        DemosTopMenuIcon.Click();
    }
}