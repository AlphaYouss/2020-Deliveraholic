using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace deliveraholic_backend.Tools
{
    public class ApiHandler
    {
        private Dictionary<string, string> properties { get; set; }

        private HttpResponseMessage response { get; set; }


        public Dictionary<string, string> CreateACall(string url, string? externalID, string? param, bool key, string? apiKey)
        {
            // Create api call:

            string apiCallUrl = url + externalID;

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(apiCallUrl)
            };

            // Make a call to "url".

            if (key != false)
            {
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            }

            if (param != null)
            {
                response = client.GetAsync("?" + param + '=' + externalID).Result;
            }
            else
            {
                response = client.GetAsync("").Result;
            }

            if (response.IsSuccessStatusCode)
            {
                // Status is OK(200).

                using HttpContent content = response.Content;

                SetAPIContent(response);
            }
            client.Dispose();
            return properties;
        }


        private void SetAPIContent(HttpResponseMessage response)
        {
            using HttpContent content = response.Content;

            properties = new Dictionary<string, string>();

            // Get content string.

            Task<string> taskContent = content.ReadAsStringAsync();
            JObject jsonContent = JObject.Parse(taskContent.Result);

            // Loop through the account properties.

            foreach (KeyValuePair<string, JToken> jsonProps in jsonContent)
            {
                string key = jsonProps.Key;
                string value = jsonProps.Value.ToString();

                properties[key] = value;
            }
        }


        public HttpResponseMessage GetResponse()
        {
            return response;
        }
    }
}