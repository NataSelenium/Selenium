using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1
{
    /// <summary>
    /// Summary description for IFrameTest
    /// Test 40: 6.	Create test with frames (URL - https://the-internet.herokuapp.com/iframe). 
    /// Write the following text – Hello world!  and check it. Do not use menu File -> New Document.
    /// </summary>
    [TestClass]
    public class IFrameTest
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void IFrameTestMethod()
        {
            //Go to the URL
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");

            //Switch to the frame with Id = 'mce_0_ifr'
            driver.SwitchTo().Frame("mce_0_ifr");

            //Find the web element body in the frame
            IWebElement bodyElement = driver.FindElement(By.Id("tinymce"));

            //Clear the text 
            bodyElement.Clear();

            //Input the text
            bodyElement.SendKeys("Hello World!");

            //Verify if body text is correct
            Assert.AreEqual("Hello World!", bodyElement.Text);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

    }
}
