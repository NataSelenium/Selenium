using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1.PageObjectTest
{
    /// <summary>
    /// Task 60: 2.	Logout from mail.ru
    /// </summary>
    [TestClass]
    public class LogoutMailRuTest
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod, TestCategory("Task 60")]
        public void LogoutMailRuTestMethod()
        {
            //Create wait object
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            //Go to the URL
            driver.Navigate().GoToUrl("https://mail.ru/");
            //Maximize window
            driver.Manage().Window.Maximize();
            //Find the 'Login' input and type the login
            driver.FindElement(By.XPath("//input[@id='mailbox:login']")).SendKeys("seleniumtests10");
            //Find the 'Password' input and type the password
            driver.FindElement(By.XPath("//input[@id='mailbox:password']")).SendKeys("060788avavav");
            //Find the 'Submit' button and click
            driver.FindElement(By.XPath("//label[@id='mailbox:submit']")).Click();
            //Wait when the 'выход' element appears  - about 7 sec with my test
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("PH_logoutLink")));
            //Find the 'выход' element and click
            driver.FindElement(By.Id("PH_logoutLink")).Click();
            //Verify if title is correct
            Assert.AreEqual("Mail.Ru: почта, поиск в интернете, новости, игры", driver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
