using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectPattert.Lection.Pages;

public class SelectmenuPage : BasePage
{
    public SelectmenuPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    private SelectElement SpeedSelectDropdown => new SelectElement(SpeedDropdown);

    protected override By UniqueWebLocator => By.XPath("//*[contains(@class, \"entry-title\") and contains(text(),\"Selectmenu\")]");
    
    protected override string UrlPath => "/selectmenu/";
    
    private IWebElement SpeedDropdown => WebDriver.FindElement(By.CssSelector("#speed"));

    public void SelectSpeed(string value)
    {
        BreakInToModalFormIFrame();
        SpeedSelectDropdown.SelectByText(value);
    }

    public string GetSpeedSelectedValue()
    {
        return SpeedSelectDropdown.SelectedOption.Text;
    }
}