using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using TechTalk.SpecFlow;

namespace E2E_tests.Drivers
{
    [Binding]
    public static class WebDriver
    {
        private static IWebDriver browser;
        public static IWebDriver current => browser ??= GetChromeDriver();


        private static IWebDriver GetChromeDriver()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);

            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Path.GetFullPath(@"Drivers\ChromeDriver\"));

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            return new ChromeDriver(service, options);
        }


        [AfterTestRun]
        public static void Kill()
        {
            if (browser == null)
                return;

            try
            {
                browser.Manage().Cookies.DeleteAllCookies();
            }
            finally
            {
                browser.Quit();
            }
        }
    }
}