using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1
{
    /// <summary>
    /// Summary description for ExplicitWebDriverWaiterTest
    /// Task 40: 4.	Add explicit waiter for following test case:
    ///     a)	Go to RMSys login page, RMSys login page should appear.
    ///     b)	Enter correct username and password, both inputs should be filled in.
    ///     c)	Click Submit button, RMSys home page should appear.
    ///     d)	Go to office tab, wait for "Search by office" input to appear(wait 15 seconds, polling frequence - 2,7 seconds).
    /// </summary>
    [TestClass]
    public class ExplicitWebDriverWaiterTest
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void ExplicitWebDriverTestMethod()
        {
            //Go to the URL
            driver.Navigate().GoToUrl("https://192.168.100.26/");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //Wait when title page becomes 'RMSys - Home'
            wait.Until(ExpectedConditions.TitleContains("RMSys - Sign In"));
            Assert.IsTrue(driver.Title == "RMSys - Sign In");

            //Input Username and password information
            driver.FindElement(By.Id("Username")).SendKeys("EugenBorisik");
            driver.FindElement(By.Id("Password")).SendKeys("qwerty12345");

            //Wait when input 'Username' is not empty
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id("Username"),"EugenBorisik"));

            //Wait when input 'Password' is not empty
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id("Password"), "qwerty12345"));

            //Click Submit button
            driver.FindElement(By.Id("SubmitButton")).Click();

            //Wait when title page becomes 'RMSys - Home'
            wait.Until(ExpectedConditions.TitleContains("RMSys - Home"));
            Assert.AreEqual("RMSys - Home", driver.Title.ToString());

            //Click the Office Tab
            driver.FindElement(By.LinkText("Office")).Click();

            //Redefine the wait variable
            wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(15), TimeSpan.FromMilliseconds(2700));

            //Wait for "Search by office" input to appear
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("input-search")));  
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
