using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Admin.Common
{
    public static class Constant
    {
        public static string FORMAT_DATE
        {
            get { return "MM/dd/yyyy"; }
        }

        public static string ACCESS_DENIED
        {
            get
            {
                return "Access is denied. Please contact administrator.";
            }
        }

        public static string SERVER_ERROR
        {
            get
            {
                return "Server error. Please contact administrator.";
            }
        }

        public static string CHANGE_PASSWORD_COMPARE
        {
            get
            {
                return "New password and confirm password did not match.";
            }
        }
        public static Guid ToGuid(this object val)
        {
            if (val == null || val == DBNull.Value)
            {
                return Guid.Empty;
            }
            return Guid.Parse(val.ToString());
        }
        public static string CHANGE_PASSWORD_CURRENTNEW
        {
            get
            {
                return "Current password and new password should not be the same.";
            }
        }

        public static string CHANGE_PASSWORD_CURRENTOLD
        {
            get
            {
                return "Current password is incorrect.";
            }
        }

        public static string CHANGE_PASSWORD_FORMAT
        {
            get
            {
                return "Password must be a minimum of 6 characters with at least 1 numeric character.";
            }
        }

        #region Global

        public static string IDENTITY_ESTABLISHMENT_TEXT = "EstablishmentID";
        public static string IDENTITY_USERPORTAL_TEXT = "UserPortalText";
        public static string IDENTITY_GLOBALBRANCHID = "GlobalBranchID";
        public static string IDENTITY_EMAILADDRESS = "GlobalEmail";
        public static string IDENTITY_GLOBALBRANCHNAME = "GlobalBranchName";
        public static string IDENTITY_GLOBAL_USERID = "GlobalUserID";
        public static string IDENTITY_GLOBAL_USERNAME = "GlobalUserName";
        public static string IDENTITY_USERROLE_ID = "UserRoleID";
        public static string IDENTITY_USERENTITY = "UserEntity";
        public static string IDENTITY_ADMINENTITY = "AdminEntity";
        public static string IDENTITY_ESTABLISHMENTLISTENTITY = "EstablishmentListEntity";

        public static string IDENTITY_ADMINROLE = "4";


        #endregion

        #region > Customer
        public const string ErrorBirtdate = "Birthday value is incorrect.";
        public const string ErrorSavingInformation = "Error saving information.";
        public const string CustomerAlreadyExist = "Customer {0}, {1} with Birthdate of {2} already exist. Unable to update information.";
        public const string CustomerHasExistingTransaction = "Customer cannot be deleted. Has existing job order!";
        public const string CustomerAddedToBranch = "Customer already exists and has been added to your branch";
        public const string VehicleAddedToBranch = "Vehicle already exists and has been added to your branch";
        public const string VehicleAlreadyExist = "Vehicle with PlateNo/Conduction Sticker {0} {1} already exist. Search for Plate No./Conduction Sticker.";
        public const string VehicleRegisteredToAnotherCustomer = "Vehicle {0} is registered to another customer.";
        public const string NoServiceOrderNo = "Cannot close J.O.without Service Order Number.";
        public const string ServicePreviouslyClosed = "{0} has been previously Closed. Information cannot be modified.";
        public const string NoTimeLogs = "Time In and Time Out are requied in closing a Job Order.";
        public const string NoServiceStartDateAndTime = "Service Start Date must have Time In value.";
        public const string NoMechanicSelected = "Mechnic is required to start a service";
        public const string ServiceDateRequired = "Time In requires Service Start Date.";
        public const string NoVehiclePlateNumber = "Vehicle {0} does not exist.";
        public const string NoVehicleNumber = "Input either Plate Number or Conduction Sticker Number.";
        public const string HasConsentDisabled = "Client refused to give consent of personal information gathering.";
        #endregion

        public static String ConvertImageURLToBase64(String url)
        {
            StringBuilder _sb = new StringBuilder();

            Byte[] _byte = GetImage(url);
            if (_byte != null)
                _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

            return _sb.ToString();
        }


        private static byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

        #region > User
        public const string UserAddedToSystem = "User has been added to your system";
        public const string ErrorUserInformation = "User value is incorrect.";
        #endregion
    }
}
