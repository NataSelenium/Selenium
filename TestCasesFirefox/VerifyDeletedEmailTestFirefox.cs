using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using GMailUnitTestProject.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GMailUnitTestProject.TestCases
{
    /// <summary>
    /// GM-5 Verify that deleted email is listed in Trash
    /// 1. Login to gmail as user 1
    /// 2. Delete some email and verify that email was added to trash
    /// </summary>
    [TestClass]
    public class VerifyDeletedEmailFirefoxTest
    {
        private IWebDriver seleniumDriver;
        const string user = "seleniumtests10";
        const string password = "060788avavav";
        const string subjectDeleted = "Nata Selenium Test GM-3 Subject Delete";
        const string firstMailInboxCssSelector = "table[id=':34'] tr:first-child span[class='y2']";
        const string deleteXpath = "//*[@id=\":5\"]/div[2]/div[1]/div/div[2]/div[3]";
        const string moreXpath = "//span[@class='CJ' and contains(text(),'More')]";
        const string binXpath = "//a[@title='Bin' and contains(text(),'Bin')]";
        private string messageDeleted = "";

        [TestMethod, TestCategory("Gmail Firefox")]
        public void VerifyDeletedEmailTestMethod()
        {
            seleniumDriver = new FirefoxDriver();
            LogicGmail logicGmail = new LogicGmail(seleniumDriver);
            logicGmail.GetPage();
            logicGmail.Login(user + "@gmail.com", password);
            messageDeleted = (logicGmail.GetEmailMessageByCssSelector(firstMailInboxCssSelector)).Substring(3, 20);
            Console.WriteLine(messageDeleted);
            logicGmail.FindAndClickWebElementByCssSelector(firstMailInboxCssSelector);       
            Thread.Sleep(1000);
            logicGmail.FindAndClickWebElementByXpath(deleteXpath);
            Thread.Sleep(1000);
            logicGmail.FindAndClickWebElementByXpath(moreXpath);
            Thread.Sleep(1000);
            logicGmail.FindAndClickWebElementByXpath(binXpath);
            Thread.Sleep(1000);
            Console.WriteLine("Message was deleted: " + messageDeleted);
            Assert.IsTrue(logicGmail.GetEmailMessageByXPathAndContent(messageDeleted).Contains(messageDeleted));
            logicGmail.Logout(user);
            LogicGmail.DriverCleanUp(seleniumDriver);
        }
    }
}
