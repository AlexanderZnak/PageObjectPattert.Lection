using OpenQA.Selenium.Chrome;
using PageObjectPattert.Lection.Pages;

namespace PageObjectPattert.Lection.Tests;

public class ModalFormTests : BaseTest
{
    [Test]
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
}