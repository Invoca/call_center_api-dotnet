using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace RingRevenue
{
    public class Call
    {
        public const int PORT = 3000;

        private Dictionary<string, object> _parameters;

        public Dictionary<string, object> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }


        public Call(Dictionary<string, object> parameters)
        {
            _parameters = parameters;
        }


        private void AddSeparator(ref string builder)
        {
            if (builder.Length > 0)
            {
                builder += '&';
            }
        }


        public string ConvertToForm(Dictionary<String, Object> og_params)
        {
            string builder = string.Empty;

            foreach (var pair in og_params)
            {
                string encodedKey = HttpUtility.UrlEncode(pair.Key);
                object value = pair.Value;
                Array list = value as Array;
                if (list != null)
                {
                    foreach (string element in list)
                    {
                        AddSeparator(ref builder);
                        builder += encodedKey + "[]=" + HttpUtility.UrlEncode(element);
                    }
                }
                else
                {
                    AddSeparator(ref builder);
                    builder += encodedKey + "=" + HttpUtility.UrlEncode(value.ToString());
                }
            }
            return builder;
        }


        public Dictionary<string, string> request(string method)
        {/*
            string uri = CallCenter.GetAPIurl();
            string parameters = ConvertToForm(Parameters);
            WebRequest request = WebRequest.Create(uri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = method;
            request.Credentials = new NetworkCredential(CallCenter.APIUsername, CallCenter.APIPassword);
            byte[] bytes = Encoding.UTF8.GetBytes(parameters);
            request.ContentLength = bytes.Length;
            Stream os = request.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            WebResponse response = request.GetResponse();
            string code = ((HttpWebResponse)response).StatusDescription;
            os = response.GetResponseStream();
            StreamReader reader = new StreamReader(os);
            string body = reader.ReadToEnd();
            reader.Close();
            os.Close();
            response.Close();
            Dictionary<string, string> x = new Dictionary<string, string>();
            x.Add("status_code", code);
            x.Add("response_body", body);
            return x;
          * */
            return new Dictionary<string, string>();
        }

        public Dictionary<string, string> save()
        { /*
            return request("PUT"); */
            return new Dictionary<string, string>();
        }
    }
}