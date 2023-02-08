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

    private IWebElement ModalFormIFrame => WebDriver.FindElement(DialogPageLocators.ModalFormIFrameLocator);

    private void BreakInToModalFormIFrame()
    {
        if (IsInModalFormIFrame)
        {
            return;
        }

        WebDriver.SwitchTo().Frame(ModalFormIFrame);
        IsInModalFormIFrame = true;
    }

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
        BreakInToModalFormIFrame();
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

    public DialogPage InputName(string name)
    {
        return this;
    }

    public DialogPage InputEmail(string email)
    {
        return this;
    }

    public DialogPage InputPassword(string pass)
    {
        return this;
    }

    public void PhoneNumber(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public void InputPhoneNumber(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public void ClickCreateAnAccountButton()
    {
        throw new NotImplementedException();
    }

    public string GetUserName()
    {
        throw new NotImplementedException();
    }
}