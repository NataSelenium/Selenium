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
        private IWebDriver seleniumDriver = new ChromeDriver();
        const string loginValue = "nataliadamorad";
        const string passwordValue = "Vintage2018";
        const string expectedTitle = "RMSys - Home";

        [TestMethod, TestCategory("Page Object Classic")]
        public void LoginClassicTestMethod()
        {
            LoginPage loginPage = new LoginPage(seleniumDriver);
            loginPage.GetPage();
            loginPage.Login(loginValue, passwordValue);
            Assert.AreEqual(expectedTitle, seleniumDriver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            LoginPage.DriverCleanUp(seleniumDriver);
        }
    }
}
