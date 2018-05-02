using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using PageFactory = SeleniumExtras.PageObjects.PageFactory;

namespace SeleniumTask1.PageFactoryTest.PageObjects
{
    public class InboxPage
    {
        IWebDriver driver;

        public InboxPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //[FindsBy(How = How.CssSelector, Using = "a[title='Sign out']")] //- doesn't work more
        //public IWebElement LogoutLink { get; set; }
        public IWebElement LogoutLink => driver.FindElement(By.CssSelector("a[title='Sign out']"));
    }
}
