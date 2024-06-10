using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Padelbooker
{
    class Program
    {
        static void Main(string[] args)
        {
            //sign in first
            IWebDriver driver = DriverManipulation.InitializeFirefoxDriver(true, "https://playtomic.io/");
            

            DriverManipulation.ClickElement(driver, ".cookies__accept > a:nth-child(1)", false); // cookies accepteren
            DriverManipulation.ClickElement(driver, "sign-buttons__sign-in", true);
            DriverManipulation.PopulateElement(driver, "sign-in__email","zve03@hotmail.com");
            DriverManipulation.PopulateElement(driver, "sign-in__password", "Zeger1995"); 
            DriverManipulation.ClickElement(driver, "sign-in__submit", true);
            string url = UrlGeneration.GenerateUrl();
            driver.Navigate().GoToUrl(url);



        }
    }
}
