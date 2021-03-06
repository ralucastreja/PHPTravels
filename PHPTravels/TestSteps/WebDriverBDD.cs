﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PHPTravels.Helpers;
using PHPTravels.Pages;
using System.Configuration;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace PHPTravels.TestSteps
{
    [Binding]
    public class WebDriverBDD
    {
        public static IWebDriver WebDriver { get; set; }

        private static bool IsReportCreated = false;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            if (!IsReportCreated)
            {
                Reporter.StartReporting();
                IsReportCreated = true;
            }

            WebDriver = new ChromeDriver(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\Drivers\\"
            );
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Reporter.StartTest(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Reporter.EndTest();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Reporter.EndReporting();
            WebDriver.Quit();
        }

        protected Homepage GoToHomepage()
        {
            string url = ConfigurationManager.AppSettings["HOME_PAGE_URL"];
            WebDriver.Navigate().GoToUrl(url);

            return new Homepage(WebDriver);
        }

        //protected DashboardPage GoToDashboardPage()
        //{
        //    string url = ConfigurationManager.AppSettings["DASHBOARD_PAGE_URL"];
        //    WebDriver.Navigate().GoToUrl(url);

        //    return new DashboardPage(WebDriver);
        //}
    }
}
