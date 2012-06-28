using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;

namespace RingRevenue
{
    /// <summary>
    /// Represents main API.
    /// </summary>

    public static class CallCenter
    {
        public static readonly Config DefaultConfig = new Config()
        {
            CallCenterID = "",
            APIVersion = "",
            APIUsername = "",
            APIPassword = ""
        };

        private static Config _config = DefaultConfig;

        public static string GetAPIurl()
        {
            Random rand = new Random();
            int api_num = rand.Next() % 2;
            return "https://api" + api_num.ToString() + ".ringrevenue.com/api/" + APIVersion + "/calls/" + CallCenterID + ".xml";
        }

        public static Config Config
        {
            get { return _config; }
            set { _config = value; }
        }

        public static string CallCenterID
        {
            get { return _config.CallCenterID; }
        }

        public static string APIVersion
        {
            get { return _config.APIVersion; }
        }

        public static string APIUsername
        {
            get { return _config.APIUsername; }
        }

        public static string APIPassword
        {
            get { return _config.APIPassword; }
        }
    }
}
