using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using GMailUnitTestProject.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GMailUnitTestProject.TestCases
{
    /// <summary>
    /// GM-2 Logout from gmail
    /// 1. Login to gmail with 'username' and 'password'
    /// 2. Logout and check that user was really signed out
    /// </summary>
    [TestClass]
    public class LogoutTest
    {
        private List<Tuple<string, string>> usersList;
        private IWebDriver seleniumDriver;

        [TestMethod, TestCategory("Gmail Chrome")]
        public void LogoutTestMethod()
        {
            GetData getData = new GetData();
            usersList = getData.GetUsersData();

            foreach (var lst in usersList)
            {
                seleniumDriver = new ChromeDriver();
                LogicGmail logicGmail = new LogicGmail(seleniumDriver);
                logicGmail.GetPage();
                logicGmail.Login(lst.Item1 + "@gmail.com", lst.Item2);
                logicGmail.Logout(lst.Item1);
                IWebElement webElement = (new WebDriverWait(seleniumDriver, TimeSpan.FromSeconds(5))).Until(ExpectedConditions.ElementIsVisible(By.Id("passwordNext")));
                Assert.AreEqual("Gmail", seleniumDriver.Title.ToString());
                LogicGmail.DriverCleanUp(seleniumDriver);
            }
        }
    }
}
