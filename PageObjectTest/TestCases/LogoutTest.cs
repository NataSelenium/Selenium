using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1.PageObjectTest.PageObjects
{
    /// <summary>
    /// Task 60: 2.	Automation project should use classic Page Object pattern.
    /// </summary>
    [TestClass]
    public class LogoutClassicTest
    {
        IWebDriver seleniumDriver;

        [TestMethod, TestCategory("Page Object Classic")]
        public void LogoutClassicTestMethod()
        {
            //Create webDriver object
            seleniumDriver = new ChromeDriver();
            //Create LoginPage object
            LoginPage loginPage = new LoginPage(seleniumDriver);
            loginPage.GetPage(loginPage.rmSysUrl);
            //Find the 'login' input and type the login
            loginPage.FindWebElementAndSendKeys(loginPage.loginId, loginPage.loginValue);
            //Find the 'password' input and type the password
            loginPage.FindWebElementAndSendKeys(loginPage.passwordId, loginPage.passwordValue);
            //Find the 'Submit' button and click
            loginPage.FindWebElementAndClick(loginPage.submitButtonId);
            //Wait when title becomes 'RMSys - Home' - about 1 min with my test
            loginPage.WaitExpectedConditionTitle(seleniumDriver, loginPage.expectedTitle);
            //Create InboxPage object
            InboxPage inboxPage = new InboxPage();
            //Wait when exit element appears on the web page - about 1 min with my test
            inboxPage.WaitExpectedConditionWebElement(seleniumDriver, inboxPage.exitCssSelector);
            //Find the 'выход' element and click
            inboxPage.FindWebElementAndClick(seleniumDriver, inboxPage.exitCssSelector);
            //Verify if title is correct
            Assert.AreEqual(inboxPage.expectedTitle, seleniumDriver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            LoginPage.DriverCleanUp(seleniumDriver);
        }
    }
}
