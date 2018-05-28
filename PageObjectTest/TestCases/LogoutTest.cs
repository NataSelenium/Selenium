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
        private IWebDriver seleniumDriver = new ChromeDriver();
        const string loginValue = "nataliadamorad";
        const string passwordValue = "Vintage2018";
        const string expectedTitle = "RMSys - Sign In";

        [TestMethod, TestCategory("Page Object Classic")]
        public void LogoutClassicTestMethod()
        {
            LoginPage loginPage = new LoginPage(seleniumDriver);
            loginPage.GetPage();
            loginPage.Login(loginValue,passwordValue);
            InboxPage inboxPage = new InboxPage(seleniumDriver);
            inboxPage.ClickExit();
            Assert.AreEqual(expectedTitle, seleniumDriver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            LoginPage.DriverCleanUp(seleniumDriver);
        }
    }
}
