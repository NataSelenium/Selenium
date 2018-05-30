using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumTask1.PageFactoryTest.PageObjects;

namespace SeleniumTask1.PageFactoryTest.TestCases
{
    /// <summary>
    /// Task 60: 1.	Automation project should use Page Factory pattern (Selenium).
    /// </summary>
    [TestClass]
    public class LogoutTest
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod, TestCategory("PageFactory")]
        public void LogoutTestMethod()
        {
            var loginPage = new LoginPage(driver);
            loginPage.GetUrl(driver);
            loginPage.LoginAccount("nataliadamorad","Vintage2018");
            var inboxPage = new InboxPage(driver);
            inboxPage.LogoutLink.Click();
            Assert.AreEqual("RMSys - Sign In", driver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
