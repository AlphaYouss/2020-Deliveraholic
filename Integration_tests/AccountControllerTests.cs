using deliveraholic_backend;
using Integration_tests.Tools;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Integration_tests
{
    public class AccountControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private TestFixture<Startup> fixture { get; set; }

        private static Random random { get; set; }

        private string requestString { get; set; }

        private MultipartFormDataContent formData { get; set; }
        private Dictionary<string, string> queries { get; set; }

        private HttpResponseMessage response { get; set; }
        private string responseValue { get; set; }

        public AccountControllerTests(TestFixture<Startup> fixture)
        {
            this.fixture = fixture;
            random = new Random();
        }


        [Fact]
        public async Task Users()
        {
            requestString = "/api/account/users";
            response = await fixture.client.GetAsync(requestString);

            responseValue = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task Deliverers()
        {
            requestString = "/api/account/users";
            response = await fixture.client.GetAsync(requestString);

            responseValue = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }


        private static string RandomStringGenerator(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        [Fact]
        public async Task RegisterUser()
        {
            var request = new
            {
                url = "/api/account/register/user",
                body = new {
                    firstName = RandomStringGenerator(15),
                    lastName = RandomStringGenerator(15),
                    email = RandomStringGenerator(15) + "@gmail.com",
                    phoneNumber = "+31651553825",
                    passwordHash = "Welkom12345"
                }
            };

            response = await fixture.client.PostAsync(request.url, ContentHelper.GetStringContent(request.body));

            responseValue = await response.Content.ReadAsStringAsync();   
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task RegisterDeliverer()
        {
            var request = new
            {
                url = "/api/account/register/deliverer",
                body = new
                {
                    firstName = RandomStringGenerator(15),
                    lastName = RandomStringGenerator(15),
                    email = RandomStringGenerator(15) + "@gmail.com",
                    phoneNumber = "+31651553825",
                    passwordHash = "Welkom12345"
                }
            };

            response = await fixture.client.PostAsync(request.url, ContentHelper.GetStringContent(request.body));
            
            responseValue = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task LoginAccount()
        {
            requestString = "/api/account/login";

            formData = new MultipartFormDataContent() {
                { new StringContent("youss.eljaddaoui@gmail.com"), "email" },
                { new StringContent("Welkom12345"), "password" }
            };

            response = await fixture.client.PostAsync(requestString, formData);
            
            responseValue = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task ForgotPassword()
        {
            requestString = "/api/account/forgot-password";

            formData = new MultipartFormDataContent() {
                { new StringContent("Youssef"), "firstname" },
                { new StringContent("El Jaddaoui"), "lastname" },
                { new StringContent("youss.eljaddaoui@gmail.com"), "email" },
                { new StringContent("Welkom12345"), "password" },
                { new StringContent("Welkom12345"), "passwordRepeat" },
            };

            response = await fixture.client.PutAsync(requestString, formData);
            
            responseValue = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task DetailsByEmail()
        {
            string email = "youss.eljaddaoui@gmail.com";

            queries = new Dictionary<string, string>
            {
                ["email"] = email,
            };

            requestString = "/api/account/byemail/" + email;
            
            response = await fixture.client.GetAsync(QueryHelpers.AddQueryString(requestString, queries));

            responseValue = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task DetailsByID()
        {
            string id = "81E348D3-1F24-EB11-8113-005056A74E91";

            queries = new Dictionary<string, string>
            {
                ["userID"] = id,
            };

            requestString = "/api/account/byid/" + id;

            response = await fixture.client.GetAsync(QueryHelpers.AddQueryString(requestString, queries));

            responseValue = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }
    }
}