using OpenQA.Selenium;

namespace PageObjectPattert.Lection.Tests;

public class WaitsTests : BaseTest
{
    [Test]
    public void ModalFormAfterClick_ShouldBeAppeared()
    {
        // open jquery site
        ProgressBarPage.OpenPage();

        ProgressBarPage.ClickStartDownloadButtonViaJs();

        var isProgressComplete = ProgressBarPage.IsDownloadFileProgressComplete(TimeSpan.FromSeconds(10));
        
        Assert.IsTrue(isProgressComplete);
    }
}