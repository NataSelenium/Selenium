using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumTask1.PageObjectTest.PageObjects
{
    /// <summary>
    /// Task 60: 2.	Automation project should use classic Page Object pattern.
    /// </summary>
    [TestClass]
    public class LoginClassicTest
    {
        IWebDriver seleniumDriver;
        const string loginValue = "nataliadamorad";
        const string passwordValue = "Vintage2018";
        const string expectedTitle = "RMSys - Home";

        [TestMethod, TestCategory("Page Object Classic")]
        public void LoginClassicTestMethod()
        {
            seleniumDriver = new ChromeDriver();
            LoginPage loginPage = new LoginPage(seleniumDriver);
            loginPage.GetPage();
            loginPage.Login(loginValue, passwordValue);
            var wait = new WebDriverWait(seleniumDriver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.TitleContains(expectedTitle));
            Assert.AreEqual(expectedTitle, seleniumDriver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            LoginPage.DriverCleanUp(seleniumDriver);
        }
    }
}
