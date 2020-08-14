using RFID.Admin.Common;
using RFID.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace RFID.Admin.Models
{
    public class GlobalModel : BaseModel
    {
        #region Properties
 
        public string GlobalEstablishmentID
        {
            get
            {
              
                return GetData<string>(Constant.IDENTITY_ESTABLISHMENT_TEXT);
            }

            set
            {
                StoredData<string>(Constant.IDENTITY_ESTABLISHMENT_TEXT, value);
            }
        }

        public string GlobalUserPortalText
        {
            get
            {
                return GetData<string>(Constant.IDENTITY_USERPORTAL_TEXT);
            }

            set
            {
                StoredData<string>(Constant.IDENTITY_USERPORTAL_TEXT, value);
            }
        }
        public string GlobalEmail
        {
            get
            {
                return GetData<string>(Constant.IDENTITY_EMAILADDRESS);
            }

            set
            {
                StoredData<string>(Constant.IDENTITY_EMAILADDRESS, value);
            }
        }

        public string GlobalUserID
        {
            get
            {
                return GetData<string>(Constant.IDENTITY_GLOBAL_USERID);
            }

            set
            {
                StoredData<string>(Constant.IDENTITY_GLOBAL_USERID, value);
            }
        }

        public string GlobalUserEntity
        {
            set
            {
                StoredData<string>(Constant.IDENTITY_USERENTITY, value);
            }
        }
        public string GlobalAdminEntity
        {
            set
            {
                StoredData<string>(Constant.IDENTITY_ADMINENTITY, value);
            }
        }

        public string GlobalEstablishmentList
        {
            set
            {
                StoredData<string>(Constant.IDENTITY_ESTABLISHMENTLISTENTITY, value);
            }
        }



        public string GlobalUserName
        {
            get
            {
                return GetData<string>(Constant.IDENTITY_EMAILADDRESS);
            }

            set
            {
                StoredData<string>(Constant.IDENTITY_EMAILADDRESS, value);
            }
        }

        public string SelectUserRoleID
        {
            get
            {
                return GetData<string>(Constant.IDENTITY_USERROLE_ID);
            }

            set
            {
                StoredData<string>(Constant.IDENTITY_USERROLE_ID, value);
            }
        }
        public string SelectUserRoleName
        {
            get
            {
                return GetData<string>("RoleName");
            }

            set
            {
                StoredData<string>("RoleName", value);
            }
        }

        public string UserImage
        {
            get
            {
                return GetData<string>("UserImage");
            }

            set
            {
                StoredData<string>("UserImage", value);
            }
        }

        public string Company
        {
            get
            {
                return GetData<string>("Company");
            }

            set
            {
                StoredData<string>("Company", value);
            }
        }

        #endregion
    }
}