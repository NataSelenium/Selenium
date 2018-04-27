using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumTask1.PageObjectTest.PageObjects
{
    class LoginPage
    {
        public IWebDriver driver;
        public string loginId = "Username";
        public string loginValue = "nataliadamorad";
        public string passwordId = "Password";
        public string passwordValue = "Vintage2018";
        public string submitButtonId = "SubmitButton";
        public string rmSysUrl = "https://192.168.100.26/";
        public string expectedTitle = "RMSys - Home";
        
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GetPage(string url)
        {
            //Go to the URL
            driver.Navigate().GoToUrl(url);
            //Maximize window
            driver.Manage().Window.Maximize();
        }

        public void FindWebElementAndSendKeys(string id, string text)
        {
            driver.FindElement(By.Id(id)).SendKeys(text);
        }

        public void FindWebElementAndClick(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public void WaitExpectedConditionTitle(IWebDriver driver, string expectedTitle)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.TitleContains(expectedTitle));
        }

        public static void DriverCleanUp(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
