using OpenQA.Selenium;

namespace SeleniumTask1.PageObjectTest.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver;
        const string loginId = "Username";
        const string passwordId = "Password";
        const string submitButtonId = "SubmitButton";
        const string rmSysUrl = "https://192.168.100.26/";
        
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
