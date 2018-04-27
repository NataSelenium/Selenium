using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1.PageObjectTest
{
    /// <summary>
    /// Tsk 60: 1.	Login to mail.ru (username - seleniumtests10@mail.ru; password - 060788avavav)
    /// </summary>
    [TestClass]
    public class LoginMailRuTest
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod, TestCategory("Task 60")]
        public void LoginMaiRuTestMethod()
        {
            //Create wait object
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            //Go to the URL
            driver.Navigate().GoToUrl("https://mail.ru/");
            //Maximize window
            driver.Manage().Window.Maximize();
            //Find the 'login' input and type the login
            driver.FindElement(By.XPath("//input[@id='mailbox:login']")).SendKeys("seleniumtests10");
            //Find the 'password' input and type the password
            driver.FindElement(By.XPath("//input[@id='mailbox:password']")).SendKeys("060788avavav");
            //Find the 'Submit' button and click
            driver.FindElement(By.XPath("//label[@id='mailbox:submit']")).Click();
            //Wait when title becomes 'Входящие - Почта Mail.Ru' - about 7-8 sec with my test
            wait.Until(ExpectedConditions.TitleContains("Входящие - Почта Mail.Ru"));
            //Verify if title is correct
            Assert.AreEqual("(5) Входящие - Почта Mail.Ru", driver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
