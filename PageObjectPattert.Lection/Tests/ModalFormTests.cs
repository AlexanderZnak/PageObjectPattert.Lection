using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium.Chrome;
using PageObjectPattert.Lection.Pages;

namespace PageObjectPattert.Lection.Tests;

[AllureNUnit]
public class ModalFormTests : BaseTest
{
    [Test]
    [AllureTag("Regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("Issue - 2")]
    [AllureTms("Tms-13")]
    [AllureOwner("Aliaksandr Znak")]
    [AllureSuite("Modal tests")]
    [AllureSubSuite("Positive")]
    public void ModalFormAfterClick_ShouldBeAppeared()
    {
        // open jquery site
        HomePage.OpenPage();

        // validate is home page opened
        Assert.True(HomePage.IsPageOpened, "HomePage should be opened");

        // go to Dialog page through left menu
        HomePage.ClickLeftMenuDialogIcon();

        // validate is Dialog page opened
        Assert.True(DialogPage.IsPageOpened, "DialogPage should be opened");

        // Open modal form through click on icon
        DialogPage.ClickModalFormIconFromExamplesTable();

        // validate is modal form appeared
        Assert.True(DialogPage.IsModalFormAppeared, "ModalForm should be opened");
    }

    [Test]
    public void ModalFormAfterClick_GetRidPageOpenAssertions_ShouldBeAppeared()
    {
        // open jquery site
        HomePage.OpenPage();

        // go to Dialog page through left menu
        HomePage.ClickLeftMenuDialogIcon();

        // Open modal form through click on icon
        DialogPage.ClickModalFormIconFromExamplesTable();

        // validate is modal form appeared
        Assert.True(DialogPage.IsModalFormAppeared, "ModalForm should be opened");
    }

    [Test]
    [AllureTag("Regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("Issue - 3")]
    [AllureTms("Tms-14")]
    [AllureOwner("Aliaksandr Znak")]
    [AllureSuite("Modal tests")]
    [AllureSubSuite("Negative")]
    public void ModalFormAfterClick_GetRidPageOpenAssertions_Negative_ShouldBeAppeared()
    {
        AllureLifecycle.Instance.WrapInStep((() => { HomePage.OpenPage(); }), "open jquery site");

        AllureLifecycle.Instance.WrapInStep((() => { HomePage.ClickLeftMenuDialogIcon(); }),
            "go to Dialog page through left menu");

        AllureLifecycle.Instance.WrapInStep((() =>
        {
            DialogPage.ClickModalFormIconFromExamplesTable();
            DialogPage.ClickModalFormIconFromExamplesTable();
            DialogPage.ClickModalFormIconFromExamplesTable();
            DialogPage.ClickModalFormIconFromExamplesTable();
            DialogPage.ClickModalFormIconFromExamplesTable();
            DialogPage.ClickModalFormIconFromExamplesTable();
            DialogPage.ClickModalFormIconFromExamplesTable();
            DialogPage.ClickModalFormIconFromExamplesTable();
            DialogPage.ClickModalFormIconFromExamplesTable();
        }), "Open modal form through click on icon");

        AllureLifecycle.Instance.WrapInStep(
            (() => { Assert.False(DialogPage.IsModalFormAppeared, "ModalForm should be opened"); }),
            "validate is modal form appeared");
    }
}