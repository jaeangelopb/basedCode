using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Helper
{
    public static class ExtensionMethods
    {
        public static DateTime ToDateTime(this object val)
        {
            if (val == null || val == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            return DateTime.Parse(val.ToString());
        }
        public static string ToStringDefault(this object val)
        {
            if (val == null || val == DBNull.Value)
            {
                return string.Empty;
            }
            return val.ToString();
        }


        public static int ToInt(this object val)
        {
            if (val == null || val == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt32(val);
        }

        public static Guid ToGuid(this object val)
        {
            if (val == null || val == DBNull.Value)
            {
                return Guid.Empty;
            }
            return Guid.Parse(val.ToString());
        }


        public static short ToShortInt(this object val)
        {
            if (val == null || val == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt16(val);
        }

        public static bool ToBooleanDefault(this object val)
        {
            if (val == null || val == DBNull.Value)
            {
                return false;
            }
            else if (val.ToStringDefault() == string.Empty)
            {
                return false;
            }
            return Convert.ToBoolean(val);
        }

        public static decimal ToDecimal(this object val)
        {
            if (val == null || val == DBNull.Value)
            {
                return 0.00m;
            }
            else if (val.ToStringDefault() == string.Empty)
            {
                return 0.00m;
            }
            return Convert.ToDecimal(val);
        }


        //public static string ToFormatPhoneNumber(this string phoneNumber)
        //{
        //    phoneNumber = Regex.Replace(phoneNumber, @"[^\d]", "");

        //    return phoneNumber;

        //}
        public static object ToDatabaseObj(this object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            Type t = value.GetType();

            if (t.Equals(typeof(string)))
            {
                if (value.ToString().Equals(string.Empty))
                    return DBNull.Value;
            }

            if (t.Equals(typeof(int)))
            {
                if (Convert.ToInt32(value) == 0)
                    return DBNull.Value;
            }

            if (t.Equals(typeof(decimal)))
            {
                if (Convert.ToDecimal(value) == 0m)
                    return DBNull.Value;
            }

            if (t.Equals(typeof(DateTime)))
            {
                if (Convert.ToDateTime(value) == DateTime.MinValue)
                    return DBNull.Value;
            }

            if (t.Equals(typeof(short)))
                if (Convert.ToInt16(value) == 0)
                    return DBNull.Value;

            if (t.Equals(typeof(Boolean)))
                if (value == null)
                    return DBNull.Value;

            if (t.Equals(typeof(Guid)))
            {
                if (value.ToStringDefault() == string.Empty)
                {
                    return DBNull.Value;
                }
                else if (Guid.Parse(value.ToString()) == Guid.Empty)
                {
                    return DBNull.Value;
                }
            }

            if (t.Equals(typeof(TimeSpan)))
            {
                if (value == null)
                    return DBNull.Value;

                TimeSpan ts = TimeSpan.Parse(value.ToString());
                if (ts == TimeSpan.MinValue)
                    return DBNull.Value;

            }
            return value;
        }
    }
}
