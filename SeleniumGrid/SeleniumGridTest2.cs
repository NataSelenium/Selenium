using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1.SeleniumGrid
{
    /// <summary>
    /// Run Selenium server on your machine and add to Selenium Grid two nodes:
    /// 1.	First node – VM on your computer.
    /// 2.	Second node – your computer.
    /// Run the tests using Selenium Grid and observe the results.
    /// </summary>
    [TestClass]
    public class SeleniumGridTest2
    {
        IWebDriver driver;

        [TestMethod, TestCategory("Task 110")]
        public void SeleniumGridTestMethod2()
        {
            var options = new FirefoxOptions();
            driver = new RemoteWebDriver(new Uri("http://10.10.102.12:4444/wd/hub"), options.ToCapabilities());
            driver.Navigate().GoToUrl("https://mail.ru/");
            //driver.Manage().Window.Maximize();
        }
        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
