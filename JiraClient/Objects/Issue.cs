using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraClient.Objects
{
    public class Issue
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public Dictionary<string, string> Fields { get; set; }
        public Dictionary<string, string> Changelog { get; set; }
    }
}
