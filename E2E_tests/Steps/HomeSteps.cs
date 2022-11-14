using deliveraholic_backend;
using E2E_tests.Drivers;
using Integration_tests.Tools;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace E2E_tests.Steps
{
    [Binding]
    public class HomeSteps : Xunit.IClassFixture<TestFixture<Startup>>
    {
        public HomeSteps(TestFixture<Startup> fixture)
        {
            string path = fixture.contentRoot + "\\bin\\Debug\\netcoreapp3.1\\deliveraholic_backend.exe";

            Backend.fullPath = path;
            Backend.solutionPath = fixture.contentRoot;
            Backend.Run();
        }


        [Given(@"I navigate to ""(.*)""")]
        public void GivenINavigateTo(string url)
        {
            WebDriver.current.Navigate().GoToUrl(url);
        }


        [Then(@"the text ""(.*)"" is visible")]
        public void TheTextIsVisible(string text)
        {
            Assert.That(WebDriver.current.PageSource.Contains(text), Is.True);
        }
    }
}