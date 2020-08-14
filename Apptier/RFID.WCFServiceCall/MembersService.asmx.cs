using RFID.ASMXService.BusinessEntities;
using RFID.ASMXService.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using RFID.Helper;

namespace RFID.WCFServiceCall
{
    /// <summary>
    /// Summary description for MembersService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MembersService : System.Web.Services.WebService
    {
        [WebMethod]
        public MemberEntityDC InsertMember(MemberEntityDC MemberEntity)
        {
            Guid rfID = Guid.Empty;
            MemberServiceManager member = new MemberServiceManager();
            MemberEntity = member.InsertMember(MemberEntity);
            return MemberEntity;
        }
        [WebMethod]
        public AdminEntityDC SaveAdministrator(AdminEntityDC AdminEntity)
        {

            MemberServiceManager member = new MemberServiceManager();
            AdminEntity = member.SaveAdministrator(AdminEntity);
            return AdminEntity;
        }
        [WebMethod]
        public AdminPropertyEntityDC SaveAdminProperty(AdminPropertyEntityDC AdminEntity)
        {

            MemberServiceManager member = new MemberServiceManager();
            AdminEntity = member.SaveAdminProperty(AdminEntity);
            return AdminEntity;
        }


        [WebMethod]
        public MemberEntityDC InserShadowMember(MemberEntityDC MemberEntity)
        {
            MemberServiceManager member = new MemberServiceManager();
            MemberEntity = member.InserShadowMember(MemberEntity);
            return MemberEntity;
        }
        [WebMethod]
        public MemberEntityDC DeleteMemberByAccountIDServer(string AccountID)
        {
            MemberEntityDC MemberEntity = new MemberEntityDC();
            MemberServiceManager member = new MemberServiceManager();
            MemberEntity = member.DeleteMemberByAccountIDServer(AccountID);
            return MemberEntity;
        }
        [WebMethod]
        public AdminPropertyListEntityDC GetAllAdminPropertyByAdminID(Guid AdminID)
        {
            AdminPropertyListEntityDC MemberEntity = new AdminPropertyListEntityDC();
            MemberServiceManager member = new MemberServiceManager();
            MemberEntity = member.GetAllAdminPropertyByAdminID(AdminID);
            return MemberEntity;
        }

        [WebMethod]
        public MemberListEntityDC GetAllMember(string Search, string AccountID, int PageIndex, int PageSize, out int Count)
        {
            MemberListEntityDC MemberEntity = new MemberListEntityDC();
            MemberServiceManager member = new MemberServiceManager();
          //  int count = 0;
            MemberEntity = member.GetAllMember(Search, AccountID, PageIndex, PageSize, out Count);
            return MemberEntity;
        }
        [WebMethod]
        public AdminListEntityDC GetAllAdministrator(string Search, string AccountID, int PageIndex, int PageSize)
        {
            AdminListEntityDC MemberEntity = new AdminListEntityDC();
            MemberServiceManager member = new MemberServiceManager();
            int count = 0;
            MemberEntity = member.GetAllAdministrator(Search, AccountID, PageIndex, PageSize, out count);
            return MemberEntity;
        }
        [WebMethod]
        public MemberListEntityDC GetAllMemberByAccountId(string AccountID)
        {
            MemberListEntityDC MemberEntity = new MemberListEntityDC();
            MemberServiceManager member = new MemberServiceManager();
            MemberEntity = member.GetAllMemberByAccountId(AccountID);
            return MemberEntity;
        }

        [WebMethod]
        public AdminEntityDC GetAdministratorByAdminID(string AdminID)
        {
            AdminEntityDC MemberEntity = new AdminEntityDC();
            MemberServiceManager member = new MemberServiceManager();
            MemberEntity = member.GetAdministratorByAdminID(AdminID);
            return MemberEntity;
        }

        [WebMethod]
        public AdminEntityDC VerifyUser(string Username, string Password)
        {
            AdminEntityDC MemberEntity = new AdminEntityDC();
            MemberServiceManager member = new MemberServiceManager();
            MemberEntity = member.VerifyUser(Username, Password);
            return MemberEntity;
        }
        [WebMethod]
        public RoleListEntityDC GetAllRole()
        {

            MemberServiceManager member = new MemberServiceManager();
            RoleListEntityDC ListAccount = new RoleListEntityDC();
            ListAccount = member.GetAllRole();
            return ListAccount;
        }
        [WebMethod]
        public GenderListEntityDC GetAllGenderType()
        {

            MemberServiceManager member = new MemberServiceManager();
            GenderListEntityDC ListAccount = new GenderListEntityDC();
            ListAccount = member.GetAllGenderType();
            return ListAccount;
        }

    }
}
