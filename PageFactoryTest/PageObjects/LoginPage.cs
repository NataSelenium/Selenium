using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;// - doesn't work
using PageFactory = SeleniumExtras.PageObjects.PageFactory;

namespace SeleniumTask1.PageFactoryTest.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //[FindsBy(How = How.Id, Using = "Username")] //- doesn't work :(
        //public IWebElement Login { get; set; }
        public IWebElement Login => driver.FindElement(By.Id("Username"));

        //[FindsBy(How = How.Id, Using = "Password")]
        //public IWebElement Password { get; set; }
        public IWebElement Password => driver.FindElement(By.Id("Password"));

        //[FindsBy(How = How.Id, Using = "SubmitButton")]
        //public IWebElement Submit { get; set; }
        public IWebElement Submit => driver.FindElement(By.Id("SubmitButton"));

        public void GetUrl(IWebDriver driver)
        {
            //Go to the URL
            driver.Navigate().GoToUrl("https://192.168.100.26/");
            //Maximize window
            driver.Manage().Window.Maximize();
        }
    }
}
