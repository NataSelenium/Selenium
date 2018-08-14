using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GMailUnitTestProject.PageObject
{
    class LogicGmail
    {
        private IWebDriver driver;
        const string gMailUrl = "https://gmail.com";
        const string title = "Gmail";

        public LogicGmail(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GetPage()
        {
            driver.Navigate().GoToUrl(gMailUrl);
            driver.Manage().Window.Maximize();
        }

        public void Login(string username, string password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.TitleContains(title));
            driver.FindElement(By.Id("identifierId")).SendKeys(username);
            driver.FindElement(By.Id("identifierNext")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("passwordNext")));
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(password);
            driver.FindElement(By.Id("passwordNext")).Click();
            Thread.Sleep(5000);
        }

        public void Logout(string username)
        {
            driver.FindElement(By.CssSelector("a[title*=\'" + username +"@gmail.com\']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("a[id=\'gb_71\']")).Click();
            Thread.Sleep(1000);
        }

        public void ComposeEmail(string recipient, string subject, string message)
        {
            driver.FindElement(By.XPath("//div[@role=\"button\" and contains(text(),'COMPOSE')]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//textarea[@name='to']")).SendKeys(recipient);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@name='subjectbox']")).SendKeys(subject);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@aria-label=\"Message Body\"]")).SendKeys(message);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@role = \"button\" and contains(text(),'Send')]")).Click();
            Thread.Sleep(1000);
        }

        public string GetEmailMessageByCssSelector(string selector)
        {
            string message = "";
            message = driver.FindElement(By.CssSelector(selector)).Text;
            return message;
        }

        public string GetEmailMessageByXpath(string XPath)
        {
            return driver.FindElement(By.XPath(XPath)).Text;
        }

        public string GetEmailMessageByXPathAndContent(string message)
        {
            return driver.FindElement(By.XPath("//span[2][@class = 'y2' and contains(text(),'" + message + "')]")).Text;
        }

        public void FindAndClickWebElementByCssSelector(string CssSelector)
        {
            driver.FindElement(By.CssSelector(CssSelector)).Click();
        }

        public void FindAndClickWebElementByXpath(string Xpath)
        {
            driver.FindElement(By.XPath(Xpath)).Click();
        }

        public static void DriverCleanUp(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
