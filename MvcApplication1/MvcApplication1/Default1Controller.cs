using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// vv correct? Is there a namespace to include, or am I defining one?
using com.ringrevenue.CallCenter;
// anything else to include?

namespace RingRevenue_Call_Center
{
    /// <summary>
    /// Represents main API.
    /// Essentially copied from James' RingRevenue_Call_Center.java github
    /// DIFFERENCES:
    ///     abstract class RingRevenue_Call_Center ==> public static class Call_Center
    ///     HashMap ==> HashSet
    ///     ArrayList ==> ArraySegment
    /// CURIOSITIES:
    ///     HashSet<String,String> brings up "Error: requires 1 type arguments" -- how to fix?
    ///     keys.add undefined
    ///     add, keySet, contains, get, put -- all should be blue -- how to fix?
    ///         change ArraySegment, change HashSet, use different methods for hm/keys?
    /// </summary>
    public static class Call_Center
    {
        public static String CALL_CENTER_ID;
        public static String API_VERSION;
        public static String API_USERNAME;
        public static String API_PASSWORD;

        public static void config(HashSet<String, String> hm)
        {
            ArraySegment<String> keys = new ArraySegment<String>();
            keys.add("CALL_CENTER_ID");
            keys.add("API_VERSION");
            keys.add("API_USERNAME");
            keys.add("API_PASSWORD");

            CALL_CENTER_ID = hm.keySet().contains("CALL_CENTER_ID") ? hm.get("CALL_CENTER_ID") : null;
            API_VERSION = hm.keySet().contains("API_VERSION") ? hm.get("API_VERSION") : null;
            API_USERNAME = hm.keySet().contains("API_USERNAME") ? hm.get("API_USERNAME") : null;
            API_PASSWORD = hm.keySet().contains("API_PASSWORD") ? hm.get("API_PASSWORD") : null;
        }

        public static HashSet<String, String> get_config()
        {
            HashSet hm = new HashSet();
            hm.put("CALL_CENTER_ID", CALL_CENTER_ID);
            hm.put("API_VERSION", API_VERSION);
            hm.put("API_USERNAME", API_USERNAME);
            hm.put("API_PASSWORD", API_PASSWORD);
            return hm;
        }
    }
}
