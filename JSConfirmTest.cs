using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1
{
    /// <summary>
    /// Summary description for JSConfirmTest
    /// 7.	Create #3.2 test for alerts (URL - https://the-internet.herokuapp.com/javascript_alerts).
    /// </summary>
    [TestClass]
    public class JSConfirmTest
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void JSConfirmTestMethod()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            //Find button for checking JS Confirm
            IWebElement button = driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']"));
            //Clicking button will show a JS Confirm with OK and cancel Button 
            button.Click();
            try
            {
                //Get the Alert        
                IAlert alert = driver.SwitchTo().Alert();
                //Click Cancel button     
                alert.Dismiss();
                //Verify if Page displays correct message
                IWebElement message = driver.FindElement(By.Id("result"));
                Assert.AreEqual("You clicked: Cancel", message.Text);
            }
            catch (NoAlertPresentException e)
            {
                e.StackTrace.ToString();
            }
        }

        [TestCleanup()]
        public void MyTestCleanup()
            {
            driver.Quit();
            }
    }
}
