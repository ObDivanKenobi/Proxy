using Microsoft.VisualStudio.TestTools.UnitTesting;
using JiraClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JiraClient.Objects;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace JiraClient.Tests
{
    [TestClass()]
    public class ConnectionTests
    {
        [TestMethod()]
        public void GetTest()
        {
            //217.25.236.230:8080/rest/api/latest/issue/FAC-30
            Connection test = new Connection("http://217.25.236.230:8080", "rest", 
                new Credentials("ObDivanKenobi", "Molotilobujnyh96"));

            var result = test.Get("/issue/FAC-30");
            string responseBody = result.Content.ReadAsStringAsync().Result;

            JObject o = JObject.Parse(responseBody);

            string id = (string)o["id"],
                key = (string)o["key"];

            var fields = o["fields"];
            string status = (string)fields["status"]["name"],
                   tmp = (string)fields["created"];

            DateTime created = DateTime.ParseExact(tmp, "MM/dd/yyyy HH:mm:ss", null);
        }
    }
}