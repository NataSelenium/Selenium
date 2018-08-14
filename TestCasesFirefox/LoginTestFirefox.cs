﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using GMailUnitTestProject.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GMailUnitTestProject.TestCases
{
    /// <summary>
    /// GM-1 Login to gmail with valid credentials
    /// 1. Go to google mail login page
    /// 2. Set 'username'
    /// 3. Set 'password'
    /// 4. Click login and check that user was really signed in
    /// </summary>
    [TestClass]
    public class LoginTestFirefox
    {
        private List<Tuple<string, string>> usersList;
        private IWebDriver seleniumDriver;

        [TestMethod, TestCategory("Gmail Firefox")]
        public void LoginTestFirefoxMethod()
        {
            GetData getData = new GetData();
            usersList = getData.GetUsersData();

            foreach (var lst in usersList)
            {
                seleniumDriver = new FirefoxDriver();
                LogicGmail logicGmail = new LogicGmail(seleniumDriver);
                logicGmail.GetPage();
                logicGmail.Login(lst.Item1 + "@gmail.com", lst.Item2);
                Assert.IsTrue(seleniumDriver.Title.Contains(lst.Item1));
                LogicGmail.DriverCleanUp(seleniumDriver);
            }
        }
    }
}

