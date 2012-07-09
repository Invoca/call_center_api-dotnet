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
        public const int PORT = 80;

        public static string CallCenterID = "";
        public static string APIVersion = "";
        public static string APIUsername = "";
        public static string APIPassword = "";
        public static int APInum = new Random().Next() % 2;

        public static string GetAPIurl()
        {
            int port = PORT; // put in port
            return "http://api" + APInum.ToString() + ".ringrevenue.com:" + port.ToString() + "/api/" + APIVersion + "/calls/" + CallCenterID + ".xml";
        }

        public static void config(Dictionary<string, string> dict)
        {
            CallCenterID = dict["CallCenterID"];
            APIVersion   = dict["APIVersion"];
            APIUsername  = dict["APIUsername"];
            APIPassword  = dict["APIPassword"];
        }
    }
}
