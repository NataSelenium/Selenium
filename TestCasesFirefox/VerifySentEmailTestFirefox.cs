﻿using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using GMailUnitTestProject.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GMailUnitTestProject.TestCases
{
    /// <summary>
    /// GM-4 Verify that sent email appears in Sent Mail folder
    /// 1. Login to gmail as user 1
    /// 2. Send email to some user
    /// 3. Go to Sent Mail and verify that email from step 2 is listed
    /// </summary>
    [TestClass]
    public class VerifySentEmailFirefoxTest
    {
        private IWebDriver seleniumDriver;
        const string sender = "seleniumtests10";
        const string recipient = "seleniumtests30";
        const string password = "060788avavav";
        const string subject = "Nata Selenium Test GM-3 Subject Firefox";
        const string message = "Nata Selenium Test GM-3 Message Firefox ...";
        const string messageChecked = "Nata Selenium Test GM-3";
        const string sentMailCssSelector = "a[title=\"Sent Mail\"]";
        const string messageCssSelector = "td[id=':dp'] span[class='y2']";
        const string messageXPath = "//td[@id=':dt']/div/div/div/span[@class='y2']";

        [TestMethod, TestCategory("Gmail Firefox")]
        public void VerifySentEmailFirefoxTestMethod()
        {
            seleniumDriver = new FirefoxDriver();
            LogicGmail logicGmail = new LogicGmail(seleniumDriver);
            logicGmail.GetPage();
            logicGmail.Login(sender + "@gmail.com", password);
            logicGmail.ComposeEmail(recipient + "@gmail.com", subject, message);
            logicGmail.FindAndClickWebElementByCssSelector(sentMailCssSelector);
            Thread.Sleep(10000);
            Assert.IsTrue(logicGmail.GetEmailMessageByXpath(messageXPath).Contains(message));
            logicGmail.FindAndClickWebElementByXpath(messageXPath);
            logicGmail.Logout(sender);
            LogicGmail.DriverCleanUp(seleniumDriver);
        }
    }
}