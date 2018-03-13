using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SeleniumTask1
{
    [TestClass]
    public class Test1
    {
        ChromeDriver driver = new ChromeDriver();
        //FirefoxDriver driver = new FirefoxDriver();
        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("https://192.168.100.26/");
            driver.FindElementById("Username").SendKeys("EugenBorisik");
            driver.FindElementById("Password").SendKeys("qwerty12345");
            driver.FindElementById("SubmitButton").Click();
            Console.WriteLine(driver.Url.ToString());

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.Url.ToString().Contains("192.168.100.26"));
        }
        [TestCleanup]
        public void TestCleanUp()
        {
            driver.FindElementByLinkText("Sign Out").Click();
            driver.Quit();
        }
    }
}
