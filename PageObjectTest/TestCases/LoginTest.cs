using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1.PageObjectTest.PageObjects
{
    /// <summary>
    /// Task 60: 2.	Automation project should use classic Page Object pattern.
    /// </summary>
    [TestClass]
    public class LoginClassicTest
    {
        IWebDriver seleniumDriver;
        
        [TestMethod, TestCategory("Page Object Classic")]
        public void LoginClassicTestMethod()
        {
            seleniumDriver = new ChromeDriver();
            LoginPage loginPage = new LoginPage(seleniumDriver);
            loginPage.GetPage(loginPage.rmSysUrl);
            //Find the 'login' input and type the login
            loginPage.FindWebElementAndSendKeys(loginPage.loginId, loginPage.loginValue);
            //Find the 'password' input and type the password
            loginPage.FindWebElementAndSendKeys(loginPage.passwordId, loginPage.passwordValue);
            //Find the 'Submit' button and click
            loginPage.FindWebElementAndClick(loginPage.submitButtonId);
            //Wait when title becomes 'Входящие - Почта Mail.Ru' - about 1 min with my test
            loginPage.WaitExpectedConditionTitle(seleniumDriver, loginPage.expectedTitle);
            //Verify if title is correct
            Assert.AreEqual(loginPage.expectedTitle, seleniumDriver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            LoginPage.DriverCleanUp(seleniumDriver);
        }
    }
}
