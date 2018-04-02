using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiraClient.Objects;

namespace JiraClient
{
    public class JiraClient
    {
        public static readonly string Localhost = "http://localhost:8080";

        private Connection _connection;

        public JiraClient(string host, string username, string password)
        {
            Credentials auth = new Credentials(username, password);
            _connection = new Connection(host, auth);
        }

        public Issue GetIssue(string key)
        {
            string resourceName = $"/issue/{key}";
            var result = _connection.Get(resourceName);

            string responseBody = result.Content.ReadAsStringAsync().Result;

            JObject o = JObject.Parse(responseBody);

            int issueId = int.Parse((string)o["id"]);                
            var fields = o["fields"];
            string status = (string)fields["status"]["name"],
                   tmp = (string)fields["created"],
                   issueKey = (string)o["key"];
            DateTime created = DateTime.ParseExact(tmp, "MM/dd/yyyy HH:mm:ss", null);

            return new Issue { Id = issueId, Key = issueKey, Status = status, Created = created };
        }
    }
}
