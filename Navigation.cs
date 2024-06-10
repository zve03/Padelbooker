using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Padelbooker
{
    public class Navigation
    {
        public static void PlaytomicWebsite()
        {
           
            string paymentUrl = UrlGeneration.GeneratePaymentUrl(14,"16","00","90");//hour 2 less in the summer!

            IWebDriver driver = DriverManipulation.InitializeFirefoxDriver(true, "https://playtomic.io/");

            //login
            DriverManipulation.ClickElement(driver, ".cookies__accept > a:nth-child(1)", false); // cookies accepteren
            DriverManipulation.ClickElement(driver, "sign-buttons__sign-in", true);
            DriverManipulation.PopulateElement(driver, "sign-in__email", "zve03@hotmail.com");
            DriverManipulation.PopulateElement(driver, "sign-in__password", "Zeger1995");
            DriverManipulation.ClickElement(driver, "sign-in__submit", true);
    
            //booking & payment
            driver.Navigate().GoToUrl(paymentUrl);
            DriverManipulation.ClickElement(driver, "/html/body/div[1]/div/div[2]/div/div/div[2]/div/div/div[4]/div[2]/div[1]/div", false); //payment method click
            DriverManipulation.ClickElement(driver, "/html/body/div[1]/div/div[2]/div/div/div[2]/div/div/div[4]/div[2]/div[2]/ul/li[1]/div/div[1]", false); //select vouchers
            DriverManipulation.ClickElement(driver, "/html/body/div[1]/div/div[2]/div/div/div[2]/div/div/div[6]/button", false);//proceed with payment
            DriverManipulation.ClickElement(driver, "/html/body/div[1]/div/div[2]/div/div/div[1]/div/div[10]/a", false);// accept

        }
    }
}
