using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1.SauceLabs
{
    /// <summary>
    /// Run auto-tests using SauceLabs cloud, created during the previous trainings, on following environments:
    /// 3. Linux, Google Chrome 40
    /// </summary>
    [TestClass]
    public class JSConfirmUnitTest
    {
        IWebDriver driver;
        public static string USERNAME = "NataSelenium";
        public static string ACCESS_KEY = "";
        public static string URL = "https://" + USERNAME + ":" + ACCESS_KEY + "ondemand.saucelabs.com:80/wd/hub";

        [TestMethod, TestCategory("Task 120")]
        public void JSConfirmUnitTestMethod()
        {
            var options = new ChromeOptions();
            options.AddAdditionalCapability(capabilityName: "browserName", capabilityValue: "Chrome");
            options.AddAdditionalCapability(capabilityName: "platform", capabilityValue: "Linux");
            options.AddAdditionalCapability(capabilityName: "version", capabilityValue: "40.0");
            driver = new RemoteWebDriver(new Uri(URL), options.ToCapabilities());
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            IWebElement button = driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']"));
            button.Click();
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Dismiss();
                IWebElement message = driver.FindElement(By.Id("result"));
                Assert.AreEqual("You clicked: Cancel", message.Text);
            }
            catch (NoAlertPresentException e)
            {
                e.StackTrace.ToString();
            }
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
