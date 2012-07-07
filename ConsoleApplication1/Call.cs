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


        private void AddParameter(ref string builder, string name, string equals, string value)
        {
            if (builder.Length > 0)
            {
                builder += '&';
            }
            builder += HttpUtility.UrlEncode(name);
            builder += equals;
            builder += HttpUtility.UrlEncode(value);
        }


        public string ConvertToForm(Dictionary<String, Object> og_params)
        {
            string builder = string.Empty;

            foreach (var pair in og_params)
            {
                object value = pair.Value;
                Array list = value as Array;
                if (list != null)
                {
                    foreach (string element in list)
                    {
                        AddParameter(ref builder, pair.Key, "[]=", element);
                    }
                }
                else
                {
                    AddParameter(ref builder, pair.Key, "=", value.ToString());
                }
            }
            return builder;
        }


        public Dictionary<string, string> save()
        {
            string uri = CallCenter.GetAPIurl();
            string parameters = ConvertToForm(Parameters);
            WebRequest request = WebRequest.Create(uri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.Credentials = new NetworkCredential(CallCenter.APIUsername, CallCenter.APIPassword);
            byte[] bytes = Encoding.UTF8.GetBytes(parameters);
            request.ContentLength = bytes.Length;
            try
            {
                using (Stream os = request.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length);
                }
                using (HttpWebResponse response)
                {
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        response = (HttpWebResponse)ex.Response;
                    }
                    using (Stream os = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(os))
                        {
                            int code    = response.StatusCode;
                            string body = reader.ReadToEnd();
                            
                            Dictionary<string, string> result = new Dictionary<string, string>();
                            result.Add("status_code", code);
                            result.Add("response_body", body);
                            return result;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Alternative exception caught.");
                Console.WriteLine(e.Message);
                return new Dictionary<string, string>();
            }
        }
    }
}
