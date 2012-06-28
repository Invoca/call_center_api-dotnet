using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.IO;

namespace RingRevenue
{
    public class Call
    {
        // verify presence of start_time_t
        const int PORT = 80;

        private Dictionary<String, Object> _parameters;

        public Dictionary<String, Object> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }


        public Call(Dictionary<String, Object> parameters)
        {
            _parameters = parameters;
        }


        public StringBuilder ConvertToForm(Dictionary<String, Object> og_params)
        {
            StringBuilder builder = new StringBuilder();
            string br = string.Empty;

            foreach (var pair in og_params)
            {
                string key = pair.Key;
                object value = pair.Value;
                Array list = value as Array;
                builder.Append(br);
                if (list != null)
                {
                    foreach (string element in list)
                    {
                        builder.Append(key + "[]=" + element);
                    }
                }
                else
                {
                    builder.Append(key + "=" + value);
                }
                br = "&";
            }

            return builder;
        }
        // escape special chars UrlHelper.Encode(string url)


        public void SetBasicAuthHeader(WebRequest req, String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            req.Headers["Authorization"] = "Basic " + authInfo;
        }


        HttpWebRequest FetchRequest()
        {
            string api_url = RingRevenue.CallCenter.GetAPIurl();
            Uri uri = new Uri(api_url);

            StringBuilder builder = ConvertToForm(Parameters);
            //vv careful
            builder.Length -= 1;

            var request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = builder.Length;
            SetBasicAuthHeader(request, RingRevenue.CallCenter.APIUsername, RingRevenue.CallCenter.APIPassword);

            var writer = new StreamWriter(request.GetRequestStream());
            writer.Write(builder.ToString(), 0, builder.Length);
            writer.Close();

            return request;
        }


        HttpWebResponse FetchResponse(HttpWebRequest request)
        {
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response;
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("The following error occured: {0}", ex.Status);
            }
        // return response -- but how??
        }


        public HttpWebResponse Save()
        {
            var request = FetchRequest();
            return FetchResponse(request);
        }
    }
}