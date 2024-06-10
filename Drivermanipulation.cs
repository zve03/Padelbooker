using System;
using System.Collections.Generic;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Padelbooker
{
    public class DriverManipulation
    {
        public static IWebDriver driverInstance;

        #region elementmanipulations (mouseclicks etc)
        public static void Escape(IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.SendKeys(OpenQA.Selenium.Keys.Escape).Build().Perform();
            System.Threading.Thread.Sleep(200); //todo not clean, should just wait for DOM
        }
        public static void WaitForElement(IWebDriver driver, string SearchValue)
        {
            //WebDriverWait tempwait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            try
            {
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            }
            catch
            {
                throw new Exception("Was waiting for " + SearchValue);
            }
        }
        public static IWebElement FindElement(IWebDriver driver, string SearchValue)
        {
            WaitForElement(driver, SearchValue);
            try
            {
                IWebElement el = driver.FindElement(By.Id(SearchValue));
                return el;
            }
            catch
            {
                throw new Exception("Could not find " + SearchValue);
            }

        }
        public static IWebDriver ClickElement(IWebDriver driver, string SearchValue, bool ById)
        {
            IWebElement el;
            if (ById == true)
            {
                el = FindElement(driver, SearchValue);
            }
            else //By XPath
            {
                try
                {
                    el = driverInstance.FindElement(By.XPath(SearchValue));
                }
                catch
                {
                    el = driverInstance.FindElement(By.CssSelector(SearchValue));
                }
            }
            try
            {
                el.Click();
                return driver;
            }
            catch
            {
                throw new Exception(SearchValue + " is not clickable");
            }
        }
        public static IWebDriver CheckElement(IWebDriver driver, string SearchValue)
        {

            IWebElement el = FindElement(driver, SearchValue);

            try
            {
                if (!el.Selected)
                {
                    el.Click();
                }
                return driver;
            }
            catch
            {
                throw new Exception(SearchValue + " is not clickable");
            }
        }
        public static IWebDriver UnCheckElement(IWebDriver driver, string SearchValue)
        {

            IWebElement el = FindElement(driver, SearchValue);

            try
            {
                if (el.Selected)
                {
                    el.Click();
                }
                return driver;
            }
            catch
            {
                throw new Exception(SearchValue + " is not clickable");
            }
        }

        public static void PopulateElement(IWebDriver driver, string SearchValue, string Input)
        {
            try
            {
                IWebElement el = FindElement(driver, SearchValue);
                el.SendKeys(Input);
            }
            catch
            {
                throw new Exception("Could not populate " + SearchValue + " with " + Input);
            }
        }
        public static void PopulateElementByXPath(IWebDriver driver, string SearchValue, string Input)
        {
            try
            {
                IWebElement el = driverInstance.FindElement(By.XPath(SearchValue));
                el.SendKeys(Input);
            }
            catch
            {
                throw new Exception("Could not populate " + SearchValue + " with " + Input);
            }
        }
        public static void ClearElement(IWebDriver driver, string SearchValue)
        {
            try
            {
                IWebElement el = FindElement(driver, SearchValue);
                el.Clear();
            }
            catch
            {
                throw new Exception("Could not clear " + SearchValue);
            }

        }
        //public static IWebDriver PopulateDropdown(IWebDriver driver, string SearchValue, string Input)
        //{
        //    try
        //    {
        //        IWebElement el = FindElement(driver, SearchValue);
        //        var selectElement = new SelectElement(el);
        //        selectElement.SelectByText(Input);
        //        return driver;
        //    }
        //    catch
        //    {
        //        throw new Exception("Could not populate dropdown " + SearchValue + " with " + Input);
        //    }
        //}
        #endregion

        #region drivers
        public static IWebDriver InitializeFirefoxDriver(bool visible, string url)
        {
            if (visible == true)
            {

                driverInstance = new FirefoxDriver();
                driverInstance.Navigate().GoToUrl(url);
            }
            else
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments("--headless");
                driverInstance = new FirefoxDriver(options);
            }

            return driverInstance;
        }
        public static IWebDriver InitializeChromeDriver()
        {
            driverInstance = new ChromeDriver();
            return driverInstance;
        }
        public static IWebDriver InitializeEdgeDriver()
        {
            driverInstance = new EdgeDriver();
            return driverInstance;
        }
        public static IWebDriver InitializeIEDriver()
        {
            var service = InternetExplorerDriverService.CreateDefaultService(@"C:\Zeger\Drivers"); // todo should be included in the solution and refer there (already included it but need to change the reference path)


            var options = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true
            };
            driverInstance = new InternetExplorerDriver(service, options);
            return driverInstance;
        }
        #endregion

    }

    #region verifications to use for testing
    public class Verify
    {
        public static bool IsClickable(IWebDriver driver, string elementid)
        {
            //System.Threading.Thread.Sleep(100);
            try
            {
                IWebElement element = driver.FindElement(By.Id(elementid)); ;
                if (element.Displayed == true && element.Enabled == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool IsPresent(IWebDriver driver, string elementid)
        {
            try
            {
                IWebElement element = driver.FindElement(By.Id(elementid));
                return true;
            }
            catch
            {
                return false;
            }

        }


    }
    #endregion
}
