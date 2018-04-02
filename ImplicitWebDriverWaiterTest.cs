using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1
{
    /// <summary>
    /// Summary description for ImplicitWebDriverWaiterTest
    /// Task 40: 1.	Add implicit waiter for WebDriver.
    /// </summary>
    [TestClass]
    public class ImplicitWebDriverWaiterTest
    {

        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void ImplicitWebDriverWaiterTestMethod()
        {
            //Go to the URL
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com");
            //Verify if page was loaded
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            //Find web element - link
            IWebElement webElement =  driver.FindElement(By.LinkText("Drag and Drop"));
            //Verify if link text is correct
            Assert.AreEqual("Drag and Drop", webElement.Text);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
