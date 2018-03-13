using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTask1
{
    public class ClassLocationSelenium
    {
        public ChromeDriver webDriver;
        public ClassLocationSelenium()
        {

        }

        public void FindWebElementByID(string id)
        {
            webDriver.FindElements(By.Id(id));
            if (webDriver == null)
            {
                Console.WriteLine("The web element with ID: " + id + " was not found");
            }
        }
        public void FindWebElementByName(string name)
        {
            webDriver.FindElement(By.Name(name));
            if (webDriver == null)
            {
                Console.WriteLine("The web element with Name: " + name + " was not found");
            }
        }
        public void FindWebElementByClassName(string className)
        {
            webDriver.FindElement(By.ClassName(className));
            if (webDriver == null)
            {
                Console.WriteLine("The web element with Class Name: " + className + " was not found");
            }
        }
        public void FindWebElemenByTagName(string tagName)
        {
            IReadOnlyList<IWebElement> elements = webDriver.FindElements(By.TagName(tagName));
            if (elements == null)
            {
                Console.WriteLine("The web element with Tag Name: " + tagName + " was not found");
            }
        }
        public void FindWebElementByLinkText(string linkText)
        {
            webDriver.FindElement(By.LinkText(linkText));
            if (webDriver == null)
            {
                Console.WriteLine("The web element with Link Text: " + linkText + " was not found");
            }
        }
        public void FindWebElementByPartialLinkText(string partialLinkText)
        {
            webDriver.FindElement(By.PartialLinkText(partialLinkText));
            if (webDriver == null)
            {
                Console.WriteLine("The web element with partial Link Text: " + partialLinkText + " was not found");
            }
        }
        public void FindWebElementByXPath(string xPath)
        {
            webDriver.FindElement(By.XPath(xPath));
            if (webDriver == null)
            {
                Console.WriteLine("The web element by XPath: " + xPath + " was not found");
            }
        }
    }
}
