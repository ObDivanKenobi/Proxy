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

        public Connection(string host, string apiName, string apiVersion)
        {
            _apiName = apiName;
            _apiVersion = apiVersion;

            _address = $"{host}/{apiName}/api/{apiVersion}";
            _httpClient = new HttpClient();
        }

        public Connection(string host, string apiName) : this(host, apiName, "latest") { }

        public Connection(string host) : this(host, "rest") { }

        public Connection() : this(_defaultServerUri) { }

        public HttpResponseMessage Get(string apiCall, string auth)
        {
            string call = _address + apiCall;

            _httpClient.GetAsync(call, )
        }
    }
}
