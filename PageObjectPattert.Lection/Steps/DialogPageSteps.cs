using OpenQA.Selenium;
using PageObjectPattert.Lection.Models;
using PageObjectPattert.Lection.Pages;

namespace PageObjectPattert.Lection.Steps;

public class DialogPageSteps
{
    private IWebDriver WebDriver { get; }

    public DialogPageSteps(IWebDriver webDriver)
    {
        WebDriver = webDriver;
    }

    private DialogPage DialogPage => new DialogPage(WebDriver);

    public DialogPageSteps CreateUser(UserRequestModel userRequestModel)
    {
        DialogPage
            .InputName(userRequestModel.Name)
            .InputEmail(userRequestModel.Email);

        DialogPage.InputPassword(userRequestModel.Password);
        DialogPage.InputPhoneNumber(userRequestModel.PhoneNumber);

        DialogPage.ClickCreateAnAccountButton();

        return this;
    }

    public DialogPageSteps GoToDialogPage()
    {
        DialogPage.OpenPage();
        DialogPage.WaitForPageLoad();

        return this;
    }

    public DialogPageSteps GoToExamplesTab()
    {
        DialogPage.ClickModalFormIconFromExamplesTable();
        // TODO Add waiting fot examples tab appearance

        return this;
    }

    public DialogPageSteps OpenCreateUserModalWindow()
    {
        DialogPage.ClickCreateUserButton();
        // TODO Add waiting fot modal window appearance
        // add smth to meet this behaviour

        return this;
    }

    public UserViewModel GetUserRowViewModel()
    {
        var name = DialogPage.GetUserName();
        var userVm = new UserViewModel()
        {
            Name = name
        };

        return userVm;
    }

    public ButtonPageSteps GoToButtonPage()
    {
        return new ButtonPageSteps();
    }
}