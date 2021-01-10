using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Model.Settings
{
    public class ServerUrl
    {

        public ServerUrl() : this("0.0.0.0", "0") { }

        public ServerUrl(string url, string port)
        {
            this.Url = url;
            this.Port = port;
        }

        public string Url { get; set; }
        public string Port { get; set; }
    }
}
