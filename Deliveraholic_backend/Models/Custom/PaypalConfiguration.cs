using PayPal.Api;
using System.Collections.Generic;

namespace deliveraholic_backend.Models.Custom
{
    public class PayPalConfiguration
    {
        static string clientID { get; set; }
        static string clientSecret { get; set; }

        static bool isTest { get; set; }


        public PayPalConfiguration(string id, string secret)
        {
            isTest = true;

            clientID = id;
            clientSecret = secret;
        }


        public static Dictionary<string, string> GetConfig()
        {
            Dictionary<string, string> config = new Dictionary<string, string>
            {
                {"mode", isTest ? "sandbox" : "live"}
            };
            return config;
        }


        private static string GetAccessToken()
        {
            return new OAuthTokenCredential(clientID, clientSecret, GetConfig()).GetAccessToken();
        }


        public APIContext GetAPIContext(string accessToken = "")
        {
            APIContext apiContext = new APIContext(string.IsNullOrEmpty(accessToken) ? GetAccessToken() : accessToken)
            {
                Config = GetConfig()
            };
            return apiContext;
        }
    }
}