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
        IWebDriver driver;

        [TestMethod, TestCategory("PageFactory")]
        public void LogoutTestMethod()
        {
            //Create webdriver object
            driver = new ChromeDriver();
            //Create LoginPage object
            var loginPage = new LoginPage(driver);
            //Go to the URL
            loginPage.GetUrl(driver);
            //Find the 'login' input and type the login
            loginPage.Login.SendKeys("nataliadamorad");
            //Find the 'password' input and type the password
            loginPage.Password.SendKeys("Vintage2018");
            //Find the 'Submit' button and click
            loginPage.Submit.Click();
            //Create InboxPage object
            var inboxPage = new InboxPage(driver);
            //Find the logout link and click
            inboxPage.LogoutLink.Click();
            //Verify if title is correct
            Assert.AreEqual("RMSys - Sign In", driver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
