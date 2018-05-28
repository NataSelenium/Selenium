using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumTask1.PageObjectTest.PageObjects
{
    class InboxPage
    {
        private IWebDriver driver;
        const string exitCssSelector = "a[title='Sign out']";

        public InboxPage(IWebDriver driver)
        {      
            this.driver = driver;
        }

        public void ClickExit()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(exitCssSelector)));
            driver.FindElement(By.CssSelector(exitCssSelector)).Click();
        }
    }
}
