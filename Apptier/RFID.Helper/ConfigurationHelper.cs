using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace RFID.Helper
{
    public class ConfigurationHelper
    {
        public readonly string RFIDConnString =
      ConfigurationManager.ConnectionStrings[string.Format("AdminModel",
          ConfigurationManager.AppSettings["Environment"].ToString())].ConnectionString;

    }
}
