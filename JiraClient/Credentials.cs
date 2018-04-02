using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClient
{
    public class Credentials
    {
        private readonly string _authString;
        public string AuthString => _authString;

        public Credentials(string username, string password)
        {
            var authByteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            _authString = Convert.ToBase64String(authByteArray);
        }
    }
}
