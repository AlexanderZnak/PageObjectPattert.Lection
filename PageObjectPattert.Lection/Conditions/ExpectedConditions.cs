using OpenQA.Selenium;

namespace PageObjectPattert.Lection.Conditions;

public static class ExpectedConditions
{
    public static Func<IWebDriver, bool> IsElementDisplayed()
    {
        return default;
    }
}