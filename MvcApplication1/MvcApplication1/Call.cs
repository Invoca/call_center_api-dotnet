using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RingRevenue
{
    public class Call
    {
        /// initialize Call object w/params
        ///     verify presence of start_time_t
        ///     
        /// is this an appropriate way to initialize a Call's properties?
        /// 
        const int PORT = 80;

        private Dictionary<String, String> _parameters;

        public Dictionary<String, String> Parameters {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public Call(Dictionary<String,String> parameters)
        {
            _parameters = parameters;
        }

        // void is a placeholder -- return type should be whatever Net::HTTP:new(uri.host, PORT).request(request)(ruby=>.NET) is
        public void Save()
        {
            string api_url = RingRevenue.Call_Center.GetAPIurl(0,2);
            // get the uri by parsing the api_url
        }
    }
}