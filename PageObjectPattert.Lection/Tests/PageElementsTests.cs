using PageObjectPattert.Lection.Helpers;
using PageObjectPattert.Lection.Models;
using PageObjectPattert.Lection.Steps;
using PageObjectPattert.Lection.TestData;

namespace PageObjectPattert.Lection.Tests;

public class PageElementsTests : BaseTest
{
    [Test]
    public void PageElements_Demo()
    {
        ButtonPage.OpenPage();

        ButtonPage.TopMenuComponent.ClickDemosTopMenuIcon();

        DialogPage.OpenPage();

        DialogPage.TopMenuComponent.ClickDownloadTopMenuIcon();
    }

    [Test]
    public void ValueObject_And_Steps_Or_Actor_Demo()
    {
        DialogPageSteps.GoToDialogPage();

        DialogPageSteps.GoToExamplesTab();

        DialogPageSteps.OpenCreateUserModalWindow();

        var user = UserRequestModelFactory.TestUser;

        DialogPageSteps.CreateUser(user);

        // assertions
    }

    [Test]
    public void ChainOfInvocation_Demo()
    {
        var user = UserRequestModelFactory.TestUser;
        var expectedUser = new UserViewModel()
        {
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber
        };

        UserViewModel actualResult = DialogPageSteps
            .GoToDialogPage()
            .GoToExamplesTab()
            .OpenCreateUserModalWindow()
            .CreateUser(user)
            .GetUserRowViewModel();

        // assertions
        Assert.AreEqual(expectedUser, actualResult);
    }
    
    [Test]
    public void Strategy_Demo()
    {
        ILoginStrategy webStrategy = new WebStrategy();
        HomePageSteps.Login(webStrategy);
    }
    
    [Test]
    public void Strategy_Demo2()
    {
        ILoginStrategy webStrategy = new RestStrategy();
        HomePageSteps.Login(webStrategy);
    }
}