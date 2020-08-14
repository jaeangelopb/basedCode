using RFID.ASMXService.BusinessEntities;
using RFID.ASMXService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessLogic
{
    public class MemberServiceManager
    {
        public MemberEntityDC InsertMember(MemberEntityDC member)
        {
            Guid rfID = Guid.Empty;
            MemberDAL MemberDAL = new MemberDAL();
            member = MemberDAL.InsertMember(member);
            return member;
        }
        public AdminEntityDC SaveAdministrator(AdminEntityDC Members)
        {
            MemberDAL memberDAL = new MemberDAL();

            Members = memberDAL.SaveAdministrator(Members);

            return Members;
        }
        public AdminPropertyEntityDC SaveAdminProperty(AdminPropertyEntityDC Members)
        {
            MemberDAL memberDAL = new MemberDAL();

            Members = memberDAL.SaveAdminProperty(Members);

            return Members;
        }
        public AdminPropertyListEntityDC GetAllAdminPropertyByAdminID(Guid AdminID)
        {
            MemberDAL memberDAL = new MemberDAL();
            AdminPropertyListEntityDC AdminProperty = new AdminPropertyListEntityDC();
            AdminProperty = memberDAL.GetAllAdminPropertyByAdminID(AdminID);

            return AdminProperty;
        }

        public MemberEntityDC InserShadowMember(MemberEntityDC Members)
        {
            MemberDAL memberDAL = new MemberDAL();

            Members = memberDAL.InserShadowMember(Members);

            return Members;
        }
        public MemberEntityDC DeleteMemberByAccountIDServer(string AccountID)
        {
            MemberDAL memberDAL = new MemberDAL();
            MemberEntityDC Members = new MemberEntityDC();
            Members = memberDAL.DeleteMemberByAccountID(AccountID);

            return Members;
        }



        public MemberListEntityDC GetAllMember(string Search, string AccountID, int PageIndex, int PageSize, out int Count)
        {
            MemberListEntityDC productResponse = new MemberListEntityDC();
            MemberEntityDC member = new MemberEntityDC();
            MemberDAL memberDAL = new MemberDAL();
            productResponse = memberDAL.GetAllMember(Search, AccountID, PageIndex, PageSize, out Count);
            return productResponse;
        }
        public AdminListEntityDC GetAllAdministrator(string Search, string AccountID, int PageIndex, int PageSize, out int Count)
        {
            AdminListEntityDC productResponse = new AdminListEntityDC();
            AdminEntityDC member = new AdminEntityDC();
            MemberDAL memberDAL = new MemberDAL();
            productResponse = memberDAL.GetAllAdministrator(Search, AccountID, PageIndex, PageSize, out Count);
            return productResponse;
        }

        public MemberListEntityDC GetAllMemberByAccountId(string AccountID)
        {
            MemberListEntityDC productResponse = new MemberListEntityDC();
            MemberEntityDC member = new MemberEntityDC();
            MemberDAL memberDAL = new MemberDAL();
            productResponse = memberDAL.GetAllMemberByAccountId(AccountID);
            return productResponse;
        }
        public AdminEntityDC GetAdministratorByAdminID(string AdminID)
        {
            AdminEntityDC productResponse = new AdminEntityDC();
            MemberDAL memberDAL = new MemberDAL();
            productResponse = memberDAL.GetAdministratorByAdminID(AdminID);
            return productResponse;
        }

        public AdminEntityDC VerifyUser(string Username, string Password)
        {
            AdminEntityDC member = new AdminEntityDC();
            MemberDAL memberDAL = new MemberDAL();
            member = memberDAL.VerifyUser(Username, Password);
            return member;
        }

        public RoleListEntityDC GetAllRole()
        {
            RoleListEntityDC productResponse = new RoleListEntityDC();
            MemberDAL MemberDAL = new MemberDAL();
            productResponse = MemberDAL.GetAllRole();
            return productResponse;
        }

        public GenderListEntityDC GetAllGenderType()
        {
            GenderListEntityDC productResponse = new GenderListEntityDC();
            MemberDAL MemberDAL = new MemberDAL();
            productResponse = MemberDAL.GetAllGenderType();
            return productResponse;
        }

    }
}
