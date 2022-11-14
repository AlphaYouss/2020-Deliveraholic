using E2E_tests.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace E2E_tests.Features
{
    [Binding]
    public class LoginSteps
    {
        [Then(@"I fill in the loginform")]
        public void ThenIFillInTheForm()
        {
            IWebElement inputEmail = WebDriver.current.FindElement(By.Id("email"));
            inputEmail.SendKeys("carson.alexander@gmail.com");

            IWebElement inputPassword = WebDriver.current.FindElement(By.Id("password"));
            inputPassword.SendKeys("Welkom12345");
        }


        [Then(@"press on login send")]
        public static void ThenPressOnSend()
        {
            Actions action = new Actions(WebDriver.current);

            IWebElement btnElement = WebDriver.current.FindElement(By.XPath("//button[@id='loginButton']"));
            action.Click(btnElement).Build().Perform();
        }


        [Then(@"I have to wait for 3 seconds")]
        public void ThenWait3Seconds()
        {
            DateTime now = DateTime.Now;

            WebDriverWait wait = new WebDriverWait(WebDriver.current, TimeSpan.FromSeconds(3))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };
            wait.Until(wd => (DateTime.Now - now) - TimeSpan.FromSeconds(3) > TimeSpan.Zero);
        }


        [Then(@"the text ""(.*)"" will be visible")]
        public void TheTextIsVisible(string text)
        {
            Assert.That(WebDriver.current.PageSource.Contains(text), Is.True);
        }
    }
}