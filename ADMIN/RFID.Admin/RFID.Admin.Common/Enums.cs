using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Admin.Common
{
    public enum EnumUserPortalAuthenticationStatus
    {
        Successful = 0,
        InvalidUsernameOrPassword = 1,
        UnauthorizedLogin = 2
    }
}
