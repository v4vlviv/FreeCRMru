using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;

namespace FreeCrmRuFramework.Tools
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        Opera,
        IE
    }

    class TestBase : DriverInit
    {
        public static readonly int TIMESPAN = 50;
        public static readonly int TIMEWAIT = 20;
        public static readonly string URL = "https://crm.free-crm.ru";
        protected bool isTestSuccess = true;

        public ExtentReports extent;
        public ExtentTest test;
        BrowserType _browserType;

        [OneTimeSetUp]
        protected void OneTimeSetup()
        {
            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        protected virtual void SetUp()
        {
            var browserType = TestContext.Parameters.Get("Browser", "Firefox");
            //Parse the browser Type, since its Enum
            _browserType = (BrowserType)Enum.Parse(typeof(BrowserType), browserType);
            //Pass it to browser
            Initialization(_browserType);
            //Initialization(BrowserType.Chrome);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        //Think about logik meyhod TakeScreenshot();
        [TearDown]
        public void TearDown()
        {
            if (!isTestSuccess)
            {
                TakeScreenshot();
            }            
            driver.Quit();
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            extent.Flush();

        }

        public void TakeScreenshot()
        {
            var counter = DateTime.Now.Ticks.ToString();
            string projectPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), counter);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile((projectPath + ".jpg").ToString(), OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
            Console.WriteLine(projectPath);
        }

        public static void Initialization(BrowserType browserType)
        {
            ChooseDriverInstance(browserType);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(TIMESPAN);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIMEWAIT);

            driver.Navigate().GoToUrl(URL);
        }

        private static void ChooseDriverInstance(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    {
                        driver = new ChromeDriver();
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        driver = new FirefoxDriver();
                        break;
                    }
                case BrowserType.Opera:
                    {
                        driver = new OperaDriver();
                        break;
                    }
                case BrowserType.IE:
                    {
                        driver = new InternetExplorerDriver();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong option");
                        break;
                    }
            }
        }
    }
}
