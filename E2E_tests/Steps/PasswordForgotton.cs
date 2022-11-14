using E2E_tests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace E2E_tests.Steps
{
    [Binding]
    public class PasswordForgotton
    {
        [Then(@"I fill in the forgotPasswordform")]
        public void ThenIFillInTheForgotPasswordform()
        {
            IWebElement inputFirstname = WebDriver.current.FindElement(By.Id("firstname"));
            inputFirstname.SendKeys("Carson");

            IWebElement inputLastname = WebDriver.current.FindElement(By.Id("lastname"));
            inputLastname.SendKeys("Alexander");

            IWebElement inputEmail = WebDriver.current.FindElement(By.Id("email"));
            inputEmail.SendKeys("carson.alexander@gmail.com");

            IWebElement inputPhonenumber = WebDriver.current.FindElement(By.Id("password"));
            inputPhonenumber.SendKeys("Welkom12345");

            IWebElement inputPassword = WebDriver.current.FindElement(By.Id("passwordRepeat"));
            inputPassword.SendKeys("Welkom12345");
        }

        [Then(@"press on forgotPassword send")]
        public void ThenPressOnForgotPasswordSend()
        {
            Actions action = new Actions(WebDriver.current);

            IWebElement btnElement = WebDriver.current.FindElement(By.XPath("//button[@id='forgotPasswordButton']"));
            action.Click(btnElement).Build().Perform();
        }
    }
}
