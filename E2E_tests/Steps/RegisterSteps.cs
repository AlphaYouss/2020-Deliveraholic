using E2E_tests.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace E2E_tests.Steps
{
    [Binding]
    public class RegisterSteps
    {
        private static Random random { get; set; }

        public RegisterSteps()
        {
            random = new Random();
        }


        [Given(@"I'm logged in, I need to logout")]
        public void GivenImLoggedInINeedToLogout()
        {
            Actions menuAction = new Actions(WebDriver.current);
            Actions logoutAction = new Actions(WebDriver.current);

            IWebElement btnMenu = WebDriver.current.FindElement(By.XPath("//label[@id='menu']"));
            menuAction.Click(btnMenu).Build().Perform();

            Wait();

            IWebElement btnLogout = WebDriver.current.FindElement(By.XPath("//a[@id='logout']"));
            logoutAction.Click(btnLogout).Build().Perform();
        }


        private void Wait()
        {
            DateTime now = DateTime.Now;

            WebDriverWait wait = new WebDriverWait(WebDriver.current, TimeSpan.FromSeconds(3))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            wait.Until(wd => (DateTime.Now - now) - TimeSpan.FromSeconds(3) > TimeSpan.Zero);
        }


        [Then(@"I navigate to ""(.*)""")]
        public void GivenINavigateTo(string url)
        {
            WebDriver.current.Navigate().GoToUrl(url);
        }


        [Then(@"I fill in the registerform")]
        public void ThenIFillInTheRegisterform()
        {
            IWebElement inputFirstname = WebDriver.current.FindElement(By.Id("firstname"));
            inputFirstname.SendKeys(RandomStringGenerator(6));

            IWebElement inputLastname = WebDriver.current.FindElement(By.Id("lastname"));
            inputLastname.SendKeys(RandomStringGenerator(6));

            IWebElement inputEmail = WebDriver.current.FindElement(By.Id("email"));
            inputEmail.SendKeys(RandomStringGenerator(6) + RandomStringGenerator(6) + "@gmail.com");

            IWebElement inputPhonenumber = WebDriver.current.FindElement(By.Id("phonenumber"));
            inputPhonenumber.SendKeys("06" + RandomNumberGenerator(8));

            IWebElement inputPassword = WebDriver.current.FindElement(By.Id("password"));
            inputPassword.SendKeys("Welkom12345");
        }


        private static string RandomStringGenerator(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private static string RandomNumberGenerator(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        [Then(@"press on register send")]
        public void ThenPressOnRegisterSend()
        {
            Actions action = new Actions(WebDriver.current);

            IWebElement btnElement = WebDriver.current.FindElement(By.XPath("//button[@id='registerButton']"));
            action.Click(btnElement).Build().Perform();
        }


        [Then(@"the text ""(.*)"" will be visible on the loginpage")]
        public void TheTextIsVisibleOnTheLoginpage(string text)
        {
            Assert.That(WebDriver.current.PageSource.Contains(text), Is.True);

            Backend.Stop();
        }
    }
}