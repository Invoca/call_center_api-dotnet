using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.IO;
using System.Net;

namespace RingRevenue
{

    class sample
    {
        static void Main()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("CallCenterID", "1");
            dict.Add("APIVersion", "2010-04-22");
            dict.Add("APIUsername", "james@ringrevenue.com");
            dict.Add("APIPassword", "firefox");
            CallCenter.config(dict);

            // create a list of parameters
            List<Dictionary<string, object>> parameters = new List<Dictionary<string, object>>();

            Dictionary<string, object> c1params = new Dictionary<string, object>();
            c1params.Add("start_time_t", 1339289018);
            c1params.Add("call_center_call_id", 91234567);
            c1params.Add("duration_in_seconds", 200);
            c1params.Add("reason_code", "Terms&Conditions");
            c1params.Add("sale_currency", "USD");
            c1params.Add("sale_amount", 1.01);
            parameters.Add(c1params);

            String[] a = { "DVD", "cleaner" };
            String[] b = { "2", "1" };

            Dictionary<string, object> c2params = new Dictionary<string, object>();
            c2params.Add("start_time_t", 1339721018);
            c2params.Add("call_center_call_id", 91234568);
            c2params.Add("duration_in_seconds", 200);
            c2params.Add("reason_code", "S");
            c2params.Add("sale_currency", "USD");
            c2params.Add("sale_amount", 1.12);
            c2params.Add("email_address", "john@doe.com");
            c2params.Add("sku_list", a);
            c2params.Add("quantity_list", b);
            parameters.Add(c2params);

            Dictionary<string, object> c3params = new Dictionary<string, object>();
            c3params.Add("start_time_t", 1340153017);
            c3params.Add("call_center_call_id", 91234569);
            c3params.Add("duration_in_seconds", 200);
            c3params.Add("reason_code", "S");
            c3params.Add("sale_currency", "USD");
            c3params.Add("sale_amount", 2.02);
            c3params.Add("called_phone_number", "+1 8888665440");
            c3params.Add("calling_phone_number", "+1 8056801218");
            parameters.Add(c3params);

            foreach (var options in parameters)
            {
                Call call = new Call(options);
                Dictionary<string, string> response = call.save();
                Console.WriteLine("status_code: {0}\nresponse_body: {1}", response["status_code"], response["response_body"]);
            }
            Thread.Sleep(15000);
        }
    }
}