using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1.SauceLabs
{
    /// <summary>
    /// Run auto-tests using SauceLabs cloud, created during the previous trainings, on following environments:
    /// 1. Windows 10, Microsoft Edge(latest version)
    /// </summary>
    [TestClass]
    public class JSAlertUnitTest
    {
        IWebDriver driver;
        public static string USERNAME = "NataSelenium";
        public static string ACCESS_KEY = "";
        public static string URL = "https://" + USERNAME + ":" + ACCESS_KEY + "ondemand.saucelabs.com:80/wd/hub";

        [TestMethod, TestCategory("Task 120")]
        public void JSAlertUnitTestMethod()
        {
            var options = new EdgeOptions();
            options.AddAdditionalCapability(capabilityName: "browserName", capabilityValue: "MicrosoftEdge");
            options.AddAdditionalCapability(capabilityName: "platform", capabilityValue: "Windows 10");
            options.AddAdditionalCapability(capabilityName: "version", capabilityValue: "17.17134");
            driver = new RemoteWebDriver(new Uri(URL), options.ToCapabilities());
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            IWebElement button = driver.FindElement(By.XPath("//button[@onclick='jsAlert()']"));
            button.Click();
            try
            {       
                IAlert alert = driver.SwitchTo().Alert();  
                alert.Accept();
                IWebElement message = driver.FindElement(By.Id("result"));
                Assert.AreEqual("You successfuly clicked an alert", message.Text);
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
