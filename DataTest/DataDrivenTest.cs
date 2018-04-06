using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1.DataTest
{
    /// <summary>
    /// Summary description for DataDrivenTest
    /// Task 40: 5.	Create DDT test, which will cover login functionality (only happy path with > 3 datasets).
    /// </summary>
    [TestClass]
    public class DataDrivenTest
    {

        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        [DeploymentItem("Data.xlsx")]
        [DeploymentItem(@"chromedriver.exe")]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data.xlsx; Persist Security Info=False;Extended Properties='Excel 12.0;HDR=Yes'", "Sheet1$", DataAccessMethod.Sequential)]
        public void DataDrivenTestMethod()
        {
            driver.Navigate().GoToUrl("https://192.168.100.26/");

            IWebElement Username = driver.FindElement(By.Id("Username"));
            Username.SendKeys((TestContext.DataRow["UserName"]).ToString());

            IWebElement Password = driver.FindElement(By.Id("Password"));
            Password.SendKeys((TestContext.DataRow["Password"]).ToString());

            driver.FindElement(By.Id("SubmitButton")).Click();

            Assert.AreEqual("RMSys - Home", driver.Title.ToString());
           
        }
        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
    }
}
