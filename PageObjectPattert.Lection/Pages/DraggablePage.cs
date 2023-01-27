using OpenQA.Selenium;

namespace PageObjectPattert.Lection.Pages;

public class DraggablePage : BasePage
{
    public DraggablePage(IWebDriver webDriver) : base(webDriver)
    {
    }

    protected override By UniqueWebLocator => 
        By.XPath("//*[contains(@class, \"entry-title\") and contains(text(),\"Draggable\")]");

    protected override string UrlPath => "/draggable/";
}