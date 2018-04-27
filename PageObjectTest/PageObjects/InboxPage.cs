using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumTask1.PageObjectTest.PageObjects
{
    class InboxPage
    {
        public string exitCssSelector = "a[title='Sign out']";
        public string expectedTitle = "RMSys - Sign In";

        public void FindWebElementAndClick(IWebDriver driver, string exit)
        {
            driver.FindElement(By.CssSelector(exit)).Click();
        }

        public void WaitExpectedConditionWebElement(IWebDriver driver, string exit)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(exit)));
        }
    }
}
