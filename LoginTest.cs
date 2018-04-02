using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SeleniumTask1
{
    /// <summary>
    /// Task 37: 1. Create test 1, which goes to RMSys login page, login with correct credentials (Username – EugenBorisik, Password – qwerty12345, URL - https://192.168.100.26/).
    /// Task 40: 2.	Add Thread.sleep for login test, which was created on previous training. What type of waiter is it (add your answer as comment near sleep)?
    /// Task 40: 3.	Add explicit waiter for login test, which will wait until Sign out link appears (after login).
    /// </summary>

    [TestClass]
    public class LoginClass
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl("https://192.168.100.26/");
            driver.FindElement(By.Id("Username")).SendKeys("EugenBorisik");
            driver.FindElement(By.Id("Password")).SendKeys("qwerty12345");
            driver.FindElement(By.Id("SubmitButton")).Click();
            Assert.AreEqual("RMSys - Home", driver.Title.ToString());
            //It's explicit waiter. The test stops running for 1000 milliseconds
            Thread.Sleep(1000);
            //Wait when the 'Sign Out' link appears
            IWebElement webElement = (new WebDriverWait(driver, TimeSpan.FromSeconds(10))).Until(driver => driver.FindElement(By.LinkText("Sign Out")));
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}
