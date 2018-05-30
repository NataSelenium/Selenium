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
    public class LoginTest
    {
        private IWebDriver driver = new ChromeDriver();

        [TestMethod, TestCategory("PageFactory")]
        public void LoginTestMethod()
        {
            var loginPage = new LoginPage(driver);
            loginPage.GetUrl(driver);
            loginPage.LoginAccount("nataliadamorad", "Vintage2018");
            Assert.AreEqual("RMSys - Home", driver.Title.ToString());
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
