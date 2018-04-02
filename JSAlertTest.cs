using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1
{
    /// <summary>
    /// Summary description for JSAlertTest
    /// 7.	Create #3.1 test for alerts (URL - https://the-internet.herokuapp.com/javascript_alerts).
    /// </summary>
    [TestClass]
    public class JSAlertTest
    {
        IWebDriver driver = new ChromeDriver();
 
        [TestMethod]
        public void JSAlertTestMethod()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            //Find button for checking JS Alert
           IWebElement button = driver.FindElement(By.XPath("//button[@onclick='jsAlert()']"));
            //Clicking button will show a Alert with OK Button 
            button.Click();
            try {
                //Get the Alert        
                IAlert alert = driver.SwitchTo().Alert();
                //Click OK button     
                alert.Accept();                
                //Verify if Page displays correct message
                IWebElement message = driver.FindElement(By.Id("result"));
                Assert.AreEqual("You successfuly clicked an alert", message.Text);
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
