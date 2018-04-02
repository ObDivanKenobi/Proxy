using JiraClient.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraClient
{
    public class Connection
    {
        static readonly string _defaultServerUri = JiraClient.Localhost;

        string _apiName;
        string _apiVersion;
        string _address;

        HttpClient _httpClient;

        public Connection(string host, string apiName, string apiVersion, Credentials credentials)
        {
            _apiName = apiName;
            _apiVersion = apiVersion;

            _address = $"{host}/{apiName}/api/{apiVersion}";
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials.AuthString);

        }

        public Connection(string host, string apiName, Credentials credentials) : this(host, apiName, "latest", credentials) { }

        public Connection(string host, Credentials credentials) : this(host, "rest", credentials) { }

        public Connection(Credentials credentials) : this(_defaultServerUri, credentials) { }

        public HttpResponseMessage Get(string apiCall)
        {
            string call = _address + apiCall;

            var response = _httpClient.GetAsync(call).Result;
            return response;
        }
    }
}
