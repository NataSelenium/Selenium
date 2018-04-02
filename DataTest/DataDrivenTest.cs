using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Data;

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
        [DataSource("System.Data.OleDb", "Provider=Microsoft.         ACE.OLEDB.12.0;Data Source=Data.xls;Persist Security          Info=False;Extended Properties='Excel 12.0;HDR=Yes'", "Data$", DataAccessMethod.Sequential)]
        public void DataDrivenTestMethod()
        {
            driver.Navigate().GoToUrl("https://192.168.100.26/");
            IWebElement Username = driver.FindElement(By.Id("Username"));
            Username.SendKeys((TestContext.DataRow["Username"]).ToString());

            IWebElement Password = driver.FindElement(By.Id("Password"));
            Password.SendKeys((TestContext.DataRow["Password"]).ToString());

            driver.FindElement(By.Id("SubmitButton")).Click();
            Assert.AreEqual("RMSys - Home", driver.Title.ToString());
            TestContext.WriteLine("The user " + (TestContext.DataRow["Username"]).ToString() +  " was sign succesfully");
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
