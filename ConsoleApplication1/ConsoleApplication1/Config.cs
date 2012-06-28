using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Represents connection options.
/// </summary>

namespace RingRevenue
{
    public class Config
    {
        // gets or sets CallCenterID
        public string CallCenterID { get; set; }

        // gets or sets APIVersion
        public string APIVersion { get; set; }

        // gets or sets APIUsername
        public string APIUsername { get; set; }

        // gets or sets APIPassword
        public string APIPassword { get; set; }
    }
}