using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Requestor
{
    public class Request
    {
        private string URL;
        public Request(string url)
        {
            URL = url;
        }
        public WebRequest get()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            var response = request.GetResponse().ContentType;


            var sURL = "http://www.example.com";
            var sb = new StringBuilder();
            var request1 = WebRequest.Create(sURL);
            HttpWebResponse content = (HttpWebResponse)request.GetResponse().ContentType;
            return response;
        }


    }
}

