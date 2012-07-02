using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RingRevenue
{
    /// <summary>
    /// Represents main API.
    /// </summary>

    public static class CallCenter
    {
        public static string CallCenterID = "";
        public static string APIVersion = "";
        public static string APIUsername = "";
        public static string APIPassword = "";
        public static int APInum = new Random().Next() % 2;

        public static string GetAPIurl()
        {
            return "http://api" + APInum.ToString() + ".ringrevenue.com:" + Call.PORT.ToString() + "/api/" + APIVersion + "/calls/" + CallCenterID + ".xml"; // put in port
        }

        public static void config(Dictionary<string, string> dict)
        {
            CallCenterID = dict["CallCenterID"];
            APIVersion = dict["APIVersion"];
            APIUsername = dict["APIUsername"];
            APIPassword = dict["APIPassword"];
        }
    }
}