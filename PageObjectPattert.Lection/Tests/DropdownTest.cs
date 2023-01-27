using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjectPattert.Lection.Tests;

public class DropdownTest : BaseTest
{
    [Test]
    public void DoDropdownActionsTest()
    {
        SelectmenuPage.OpenPage();

        var value = "Fast";
        
        SelectmenuPage.SelectSpeed(value);

        SelectmenuPage.GetSpeedSelectedValue();
    }
}