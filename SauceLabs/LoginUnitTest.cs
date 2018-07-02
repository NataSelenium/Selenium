using System;
using System.Text;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1.SauceLabs
{
    /// <summary>
    /// Run auto-tests using SauceLabs cloud, created during the previous trainings, on following environments:
    /// 2. Windows 8.1, Mozilla Firefox 39.0
    /// </summary>
    [TestClass]
    public class LoginUnitTest
    {
        IWebDriver driver;
        public static string USERNAME = "NataSelenium";
        public static string ACCESS_KEY = "";
        public static string URL = "https://" + USERNAME + ":" + ACCESS_KEY + "ondemand.saucelabs.com:80/wd/hub";

        [TestMethod, TestCategory("Task 120")]
        public void LoginUnitTestMethod()
        {
            var options = new FirefoxOptions();
            options.AddAdditionalCapability(capabilityName: "browserName", capabilityValue: "Firefox");
            options.AddAdditionalCapability(capabilityName: "platform", capabilityValue: "Windows 8.1");
            options.AddAdditionalCapability(capabilityName: "version", capabilityValue: "39.0");
            driver = new RemoteWebDriver(new Uri(URL), options.ToCapabilities());
            driver.Navigate().GoToUrl("https://192.168.100.26/");
            driver.FindElement(By.Id("Username")).SendKeys("NataliaDamorad");
            driver.FindElement(By.Id("Password")).SendKeys("BuenosAires20");
            driver.FindElement(By.Id("SubmitButton")).Click();
        }
        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
