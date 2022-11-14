using deliveraholic_backend;
using Integration_tests.Tools;
using System.Net.Http;
using Xunit;

namespace Integration_tests
{
    public class OrderControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private string request { get; set; }
        private HttpResponseMessage response { get; set; }
        private string json { get; set; }
        private TestFixture<Startup> fixture { get; set; }


        public OrderControllerTests(TestFixture<Startup> fixture)
        {
            this.fixture = fixture;
        }


        [Fact]
        public void TestIsDisposed()
        {
            fixture.Dispose();

            Assert.True(fixture.isDisposed);
        }
    }
}