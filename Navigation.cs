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

        public static void WeekStartingInXDays(int delay)
        {
            for (int i = delay; i < 10; i++)
            {
                BookAllFields(i, "18");
                BookAllFields(i, "17");

            }
        }
        public static void BookAllFields(int adddays, string hourminustwo)
        {
            IWebDriver driver = null;
            bool success = false;
            string statement = null;
            string hour = hourminustwo; //+2 zomeruur
            string minutes = "00";
            string duration = "90";

            try
            {

                driver = SignIn();
                Console.WriteLine("Sign in successful");
            }
            catch
            {
                Console.WriteLine("Sign in failed");
                throw new Exception();
            }



            Console.WriteLine("Starten met zoeken naar velden op " + DateTime.Today.AddDays(adddays).ToString() + " - " + hour + "h(+2)" + minutes + " - " + duration + "m");
            try //try olympiade first
            {
                for (int i = 1; i < 7; i++)
                    try
                    {
                        Navigation.BookField(driver, "Olympiade", i, adddays, hour, minutes, duration);
                        success = true;
                        statement = "Boeking SUCCESVOL: Olympiade - Veld " + i.ToString() + " - " + DateTime.Today.AddDays(adddays).ToString() + " - " + hour + "h(+2)" + minutes + " - " + duration + "m";
                        Console.WriteLine(statement);
                        break;
                    }
                    catch
                    {
                        statement = "Geen boeking Olympiade veld " + i;
                        Console.WriteLine(statement);
                        continue;
                    }

            }
            catch { }
            if (success == false)
            {
                try //Berchem now
                {
                    for (int i = 1; i < 4; i++)
                        try
                        {
                            Navigation.BookField(driver,"Berchem", i, 14, hour, minutes, duration);

                            success = true;
                            statement = "Boeking SUCCESVOL: Berchem - Veld " + i.ToString() + " - " + DateTime.Today.AddDays(adddays).ToString() + " - " + hour + "h(+2)" + minutes + " - " + duration + "m";
                            Console.WriteLine(statement);
                            break;
                        }
                        catch
                        {
                            statement = "Geen boeking Berchem veld " + i;
                            Console.WriteLine(statement);
                            continue;
                        }

                }
                catch { }
            }
            driver.Close();
            Console.WriteLine("finaal geboekt: " + success);
        }
        public static void BookField(IWebDriver driver, string location, int field, int adddays, string hourminus2,string minutes, string duration)
        {
           
            try
            {


                //booking & payment
                string paymentUrl = UrlGeneration.GeneratePaymentUrl(location, field, adddays, hourminus2, minutes, duration);//hour 2 less in the summer!
                driver.Navigate().GoToUrl(paymentUrl);
                DriverManipulation.ClickElement(driver, "/html/body/div[1]/div/div[2]/div/div/div[2]/div/div/div[4]/div[2]/div[1]/div", false); //payment method click
                DriverManipulation.ClickElement(driver, "/html/body/div[1]/div/div[2]/div/div/div[2]/div/div/div[4]/div[2]/div[2]/ul/li[1]/div/div[1]", false); //select vouchers
                DriverManipulation.ClickElement(driver, "/html/body/div[1]/div/div[2]/div/div/div[2]/div/div/div[6]/button", false);//proceed with payment
                DriverManipulation.ClickElement(driver, "/html/body/div[1]/div/div[2]/div/div/div[1]/div/div[10]/a", false);// accept
                
            }
            catch
            {
 
                throw  new Exception();
            }


        }
        public static IWebDriver SignIn()
        {
            IWebDriver driver = DriverManipulation.InitializeFirefoxDriver(true, "https://playtomic.io/");

            //login
            DriverManipulation.ClickElement(driver, ".cookies__accept > a:nth-child(1)", false); // cookies accepteren
            DriverManipulation.ClickElement(driver, "sign-buttons__sign-in", true);
            DriverManipulation.PopulateElement(driver, "sign-in__email", "zve03@hotmail.com");
            DriverManipulation.PopulateElement(driver, "sign-in__password", "Zeger1995");
            DriverManipulation.ClickElement(driver, "sign-in__submit", true);
            return driver;
        }

    }
}
