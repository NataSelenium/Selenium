using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumTask1.PageObjectTest.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        const string loginId = "Username";
        const string passwordId = "Password";
        const string submitButtonId = "SubmitButton";
        const string rmSysUrl = "https://192.168.100.26/";
        const string title = "RMSys - Sign In";

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GetPage()
        {
            driver.Navigate().GoToUrl(rmSysUrl);
            driver.Manage().Window.Maximize();
        }

        public void Login(string username, string password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.TitleContains(title));
            driver.FindElement(By.Id(loginId)).SendKeys(username);
            driver.FindElement(By.Id(passwordId)).SendKeys(password);
            driver.FindElement(By.Id(submitButtonId)).Click();
        }

        public static void DriverCleanUp(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
