using OpenQA.Selenium;

namespace PageObjectPattert.Lection.Tests;

public class JsExecutorTests : BaseTest
{
    [Test]
    public void JsExecutorTest()
    {
        // open jquery site
        ProgressBarPage.OpenPage();

        ProgressBarPage.ClickStartDownloadButton();

        var isProgressComplete = ProgressBarPage.IsDownloadFileProgressComplete();

        Assert.IsTrue(isProgressComplete);
    }

    [Test]
    public void AlertInteractionTest()
    {
        // open jquery site
        ProgressBarPage.OpenPage();

        ProgressBarPage.CreateAlert();

        var expectedAlertText = "Hello World";
        var actualAlertText = ProgressBarPage.GetAlertText();

        Assert.AreEqual(expectedAlertText, actualAlertText);

        ProgressBarPage.ConfirmAlert();
    }
}