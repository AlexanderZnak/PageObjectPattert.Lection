using OpenQA.Selenium;

namespace PageObjectPattert.Lection.Locators;

public static class DialogPageLocators
{
    public static readonly By ModalFormIconLocator = 
        By.XPath("//*[@class=\"demo-list\"]//*[text()=\"Modal form\"]");

    public static readonly By UserButtonLocator = By.CssSelector("#create-user");

    public static readonly By ModalFormIFrameLocator = By.CssSelector(".demo-frame");
}