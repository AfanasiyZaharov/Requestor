using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class Request
    {
        private string URL;
        public Request(string url)
        {
            URL = url;
        }
        public WebResponse get()
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            var response = request.GetResponse();
            return response;
        }


    }

