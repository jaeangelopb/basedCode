using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace RFID.Admin.Models
{
    public class BaseModel
    {
        protected void StoredData<DataType>(string key, DataType value)
        {
            HttpContext.Current.Session[key] = value;

            HttpContext.Current.Response.Cookies[key].Value = value.ToString();
        }

        protected void StoredDataJSON<DataType>(string key, DataType value)
        {
            HttpContext.Current.Session[key] = new JavaScriptSerializer().Serialize(value);
            HttpContext.Current.Response.Cookies[key].Value = new JavaScriptSerializer().Serialize(value);
        }

        protected DataType GetData<DataType>(string key)
        {
            var value = HttpContext.Current.Session[key];

            if (value == null)
            {
                if (HttpContext.Current.Request.Cookies[key] != null)
                {
                    string val = HttpContext.Current.Request.Cookies[key].Value;

                    if (!string.IsNullOrEmpty(val))
                    {
                        return (DataType)(object)val;
                    }
                }

                return default(DataType);
            }

            return (DataType)HttpContext.Current.Session[key];
        }



        protected int GetDataInt(string key)
        {
            var value = HttpContext.Current.Session[key];

            if (value == null)
            {
                if (HttpContext.Current.Request.Cookies[key] != null)
                {
                    string data = HttpContext.Current.Request.Cookies[key].Value;

                    if (!string.IsNullOrEmpty(data))
                        return Convert.ToInt32(data);
                }

                return 0;
            }

            return 0;
        }
    }
}