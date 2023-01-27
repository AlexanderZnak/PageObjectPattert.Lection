using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjectPattert.Lection.Tests;

public class ActionTests : BaseTest
{
    [Test]
    public void ActionDragAndDropByOffsetTest()
    {
        DraggablePage.OpenPage();
        
        DraggablePage.BreakInToModalFormIFrame();

        Actions actions = new Actions(WebDriver);
        IWebElement holdElement = WebDriver.FindElement(By.CssSelector("#draggable"));

        var position = holdElement.Location;
        actions
            .DragAndDropToOffset(holdElement, position.X + 15, position.Y - 15)
            .Perform();
    }
    
    [Test]
    public void ActionDragAndDropByHoldingTest()
    {
        DraggablePage.OpenPage();
        
        DraggablePage.BreakInToModalFormIFrame();

        Actions actions = new Actions(WebDriver);
        IWebElement holdElement = WebDriver.FindElement(By.CssSelector("#draggable"));

        var position = holdElement.Location;
        var desiredPosition = new Point(position.X + 15, position.Y - 15);
        
        actions
            .ClickAndHold(holdElement)
            .MoveByOffset(desiredPosition.X, desiredPosition.Y)
            .Release()
            .Build()
            .Perform();
    }
    
    [Test]
    public void ActionMoveToElementTest()
    {
        DraggablePage.OpenPage();

        Actions actions = new Actions(WebDriver);
        IWebElement elementToMove = WebDriver.FindElement(By.CssSelector(".view-source"));

        actions
            .MoveToElement(elementToMove)
            .Perform();
    }
    
    [Test]
    public void AnotherActionToElementTest()
    {
        DraggablePage.OpenPage();

        Actions actions = new Actions(WebDriver);
        IWebElement elementToMove = WebDriver.FindElement(By.CssSelector(".view-source"));

        // mouse's wheel interactions
        // WheelInputDevice wheelInputDevice = new WheelInputDevice();
        // wheelInputDevice.CreateWheelScroll();
    }
}