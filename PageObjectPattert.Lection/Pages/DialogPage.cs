using OpenQA.Selenium;
using PageObjectPattert.Lection.Locators;

namespace PageObjectPattert.Lection.Pages;

public class DialogPage : BasePage
{
    public DialogPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    private bool IsInModalFormIFrame { get; set; }

    protected override By UniqueWebLocator =>
        By.XPath("//*[contains(@class, \"entry-title\") and contains(text(),\"Dialog\")]");

    protected override string UrlPath => "/dialog/";

    private IWebElement ModalFormIcon => WebDriver.FindElement(DialogPageLocators.ModalFormIconLocator);

    private IWebElement CreateUserButton => WebDriver.FindElement(DialogPageLocators.UserButtonLocator);

    public bool IsModalFormAppeared
    {
        get
        {
            bool isModalFormAppeared;
            try
            {
                BreakInToModalFormIFrame();
                isModalFormAppeared = CreateUserButton.Displayed;
            }
            catch (Exception e)
            {
                isModalFormAppeared = false;
            }

            return isModalFormAppeared;
        }
    }

    public void ClickModalFormIconFromExamplesTable()
    {
        ModalFormIcon.Click();
    }

    public void ClickCreateUserButton()
    {
        ClickCreateUserButtonUnsuccessful();
        WaitForPageLoad();
    }

    public void ClickCreateUserButtonUnsuccessful()
    {
        CreateUserButton.Click();
    }
}