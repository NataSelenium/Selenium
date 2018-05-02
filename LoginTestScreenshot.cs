using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTask1
{
    /// <summary>
    /// 1.	Make screenshot of login page of RMSys while running tests, created on previous training.
    /// </summary>
    [TestClass]
    public class LoginTestScreenshot
    {
        IWebDriver driver;
        string fileLocation = @"C:\FileLocation\";
        int imageCount = 0;
        
        [TestMethod, TestCategory("ScreenShot Task70")]
        public void LoginTestScreenShotMethod()
        {
            //Create driver object
            driver = new ChromeDriver();
            //Go to the URL
            driver.Navigate().GoToUrl("https://192.168.100.26/");
            //Maximize the window
            driver.Manage().Window.Maximize();
            //Set timeout for 5 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Verify if destination folder exists, otherwise create it
            VerifyFileFolder();
            //Get number of screenshot, which will be saved
            imageCount = GetImageCout() + 1;
            //Save the screenshot
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileLocation + "ScreenShot" + imageCount.ToString(),ScreenshotImageFormat.Jpeg);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }

        public void VerifyFileFolder()
        {
            DirectoryInfo di = new DirectoryInfo(fileLocation);
            try
            {
                if (di.Exists)
                {
                    Console.WriteLine("The folder already exists");
                }
                else
                {
                    di.Create();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: " + e);
            }

        }
        public int GetImageCout()
        {
            int count = 0;
            DirectoryInfo di = new DirectoryInfo(fileLocation);
            count = di.GetFiles().Length;
            return count;
        }

    }
}
