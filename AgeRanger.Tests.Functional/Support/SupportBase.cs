using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AgeRanger.Tests.Functional.Support
{
    public class SupportBase
    {
        protected static IWebDriver webDriver;

        public static void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(@"http://localhost:23090/");
            webDriver.Manage().Window.Maximize();
        }

        public void WaitForElementVisible(By by, int timeOutInSeconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.Seconds);
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        public static void Cleanup()
        {
            webDriver.Close();
        }
    }
}
