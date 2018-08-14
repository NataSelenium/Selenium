using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using GMailUnitTestProject.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GMailUnitTestProject.TestCases
{
    /// <summary>
    /// GM-3 Verify the ability to send emails
    /// 1. Login to gmail as user 1
    /// 2. Send email to user 2
    /// 3. Login as user 2 and verify that email has came
    /// </summary>
    [TestClass]
    public class SendEmailTest
    {
        private IWebDriver seleniumDriver;
        const string sender = "seleniumtests10";
        const string recipient = "seleniumtests30";
        const string password = "060788avavav";
        const string subject = "Nata Selenium Test GM-3 Subject";
        const string message = "Nata Selenium Test GM-3 Message";

        [TestMethod, TestCategory("Gmail Chrome")]
        public void SendEmailTestMethod()
        {

            seleniumDriver = new ChromeDriver();
            LogicGmail logicGmail = new LogicGmail(seleniumDriver);
            logicGmail.GetPage();
            logicGmail.Login(sender + "@gmail.com", password);
            logicGmail.ComposeEmail(recipient + "@gmail.com", subject, message);
            logicGmail.Logout(sender);
            LogicGmail.DriverCleanUp(seleniumDriver);
            logicGmail = null;

            seleniumDriver = new ChromeDriver();
            logicGmail = new LogicGmail(seleniumDriver);
            logicGmail.GetPage();
            logicGmail.Login(recipient + "@gmail.com", password);
            Thread.Sleep(10000);
            Assert.IsTrue(logicGmail.GetEmailMessageByXPathAndContent(message).Contains(message));
            logicGmail.Logout(recipient);
            LogicGmail.DriverCleanUp(seleniumDriver);
        }
    }
}
