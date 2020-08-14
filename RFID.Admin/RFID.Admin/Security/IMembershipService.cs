using RFID.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RFID.Admin.Security
{
    public interface IMembershipService
    {
        EnumUserPortalAuthenticationStatus ValidateAdmin(string userName, string password);

        //UserEntity GetUserID(Guid userID);

        //UserEntity UpdateUser(UserEntity user);
        //bool IsActive(string username);
    }
}