using OpenQA.Selenium;

namespace SeleniumTask1.PageObjectTest.PageObjects
{
    class InboxPage
    {
        IWebDriver driver;
        const string exitCssSelector = "a[title='Sign out']";

        public InboxPage(IWebDriver driver)
        {      
            this.driver = driver;
        }

        public void ClickExit()
        {
            driver.FindElement(By.CssSelector(exitCssSelector)).Click();
        }
    }
}
