using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1
{
    /// <summary>
    /// Summary description for JSPromptTest
    /// 7.	Create #3.3 test for alerts (URL - https://the-internet.herokuapp.com/javascript_alerts).
    /// </summary>
    [TestClass]
    public class JSPromptTest
    {
        IWebDriver driver = new ChromeDriver();

         [TestMethod]
        public void JSPromptTestMethod()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            //Find button for checking JS Confirm
            IWebElement button = driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']"));
            //Clicking button will show a JS Confirm with OK and cancel Button 
            button.Click();
            try
            {
                //Get the Alert        
                IAlert alert = driver.SwitchTo().Alert();
                //Enter some text
                alert.SendKeys("Hello Prompt!");
                //Click Ok button     
                alert.Accept();
                //Verify if Page displays correct message
                IWebElement message = driver.FindElement(By.Id("result"));
                Assert.AreEqual("You entered: Hello Prompt!", message.Text);
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
