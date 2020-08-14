using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RFID.Admin.Common;
using RFID.Admin.Security;
using RFID.Admin.BLL;

using RFIDAdmin.BLL.MembersService;
using RFID.Admin.Models;

namespace RFID.Admin.Security
{
    public class AccountMembershipService : IMembershipService
    {
        private AdminEntityDC data;

        public EnumUserPortalAuthenticationStatus ValidateAdmin(string username, string password)
        {
            MemberBLL bll = new MemberBLL();
            //ResultMessageDC response = new ResultMessageDC();
             AdminEntityDC MemberEntityDC = new AdminEntityDC();
            MemberEntityDC = bll.VerifyUser(username, password);

            if (MemberEntityDC.roleID != "0")
            {
                if (MemberEntityDC.adminID != Guid.Empty)
                {

                    GlobalModel globalModel = new GlobalModel();

                    globalModel.GlobalEmail = MemberEntityDC.emailAddress;
                    globalModel.GlobalUserPortalText = string.Format("{0} {1}", MemberEntityDC.firstName,
                        MemberEntityDC.lastName);
                    globalModel.GlobalUserID = MemberEntityDC.adminID.ToString();
                    globalModel.SelectUserRoleID = MemberEntityDC.roleID;
                  //  globalModel.SelectUserRoleName = data.RoleName;
                  //  globalModel.UserImage = data.ProfilePhoto;
                 //   globalModel.Company = data.CompanyID;

                    return EnumUserPortalAuthenticationStatus.Successful;


                }
            }
            else
                return EnumUserPortalAuthenticationStatus.UnauthorizedLogin;


            return EnumUserPortalAuthenticationStatus.InvalidUsernameOrPassword;
        }

   
    }
}