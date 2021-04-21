using BoDi;
using DemoQAAdvanced.pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace DemoQAAdvanced.step_definitions
{
    [Binding]
    public class DroppableSteps
    {
        private DroppablePage DroppablePage { get; set; }
        public IObjectContainer container { get; private set; }
        public IWebDriver driver { get; private set; }
        public IConfiguration config { get; private set; }
        public Actions action { get; private set; }

        public DroppableSteps(IObjectContainer container)
        {
            this.container = container;
            driver = container.Resolve<IWebDriver>();
            config = container.Resolve<IConfiguration>();
            action = container.Resolve<Actions>();
            DroppablePage = new DroppablePage(driver);
        }


        [When(@"the user drags the box to the drop zone")]
        public void WhenTheUserDragsTheBoxToTheDropZone()
        {
            action
                .DragAndDrop(DroppablePage.DraggableBox, DroppablePage.DroppableBox)
                .Build()
                .Perform();
        }
        
        [Then(@"a drop message is shown")]
        public void ThenAnDragMessageIsShown()
        {
            Assert.AreEqual("Dropped!", DroppablePage.DroppableBox.Text);
        }
    }
}
