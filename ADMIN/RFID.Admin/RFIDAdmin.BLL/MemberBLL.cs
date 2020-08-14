using System;
using RFIDAdmin.BLL.MembersService;
using System.Collections.Generic;
using RFIDAdmin.BLL.LogsService;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Admin.BLL
{
    public class MemberBLL
    {
       public  MemberEntityDC InsertMember(MemberEntityDC member)
        {
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.InsertMember(member);
        }
        //public MemberEntityDC InsertMembertoComputeStick(MemberEntityDC member)
        //{
        ////    Member memberDC = new Member();
        // //   memberDC = BusinessEntities.Translator.MemberTranslatorCompute.TranslateEntityToDC(member);
        //    LogsServiceSoapClient membersrv = new LogsServiceSoapClient();
        //    return membersrv.InsertMember(memberDC);
        //}



        public AdminEntityDC SaveAdministrator(AdminEntityDC Admin)
        {
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.SaveAdministrator(Admin);
        }
        public MemberEntityDC InserShadowMember(MemberEntityDC Members)
        {
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.InserShadowMember(Members);
        }
        public MemberEntityDC DeleteMemberByAccountIDServer(string AccountID)
        {
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.DeleteMemberByAccountIDServer(AccountID);
        }
        public MemberListEntityDC GetAllMember(string Search, string AccountID, int PageIndex, int PageSizes, out int Count)
        {
            MemberListEntityDC MemberListEntityDC = new MemberListEntityDC();
            MemberListEntityDC AdminDC = new MemberListEntityDC();
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            //int count = 0;
            return membersrv.GetAllMember(Search, AccountID, PageIndex, PageSizes, out Count);
        }
        public AdminListEntityDC GetAllAdministrator(string Search, string AccountID, int PageIndex, int PageSize)
        {
            AdminListEntityDC MemberListEntityDC = new AdminListEntityDC();
            AdminEntityDC MemberEntityDC = new AdminEntityDC();
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.GetAllAdministrator(Search, AccountID, PageIndex, PageSize);
        }

        public MemberListEntityDC GetAllMemberByAccountId(string AccountID)
        {
            MemberListEntityDC MemberListEntityDC = new MemberListEntityDC();
            MemberEntityDC MemberEntityDC = new MemberEntityDC();;
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.GetAllMemberByAccountId(AccountID);
        }
        public AdminPropertyListEntityDC GetAllAdminPropertyByAdminID(Guid AdminID)
        {
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.GetAllAdminPropertyByAdminID(AdminID);
        }
        public AdminEntityDC GetAdministratorByAdminID(string AdminID)
        {
            AdminListEntityDC MemberListEntityDC = new AdminListEntityDC();
            AdminEntityDC MemberEntityDC = new AdminEntityDC();
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.GetAdministratorByAdminID(AdminID);
        }

        public AdminEntityDC VerifyUser(string Username, string Password)
        {
            AdminEntityDC member = new AdminEntityDC();
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            member = membersrv.VerifyUser(Username, Password);
            return member;
        }

        public MemberEntityDC DeleteMemberByAccountID(string AccountID)
        {
            MemberEntityDC MemberEntityDC = new MemberEntityDC();
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.DeleteMemberByAccountIDServer(AccountID);

        }
        public RoleListEntityDC GetAllRole()
        {
            RoleListEntityDC MemberListEntityDC = new RoleListEntityDC();
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();

            return membersrv.GetAllRole();
        }
        public GenderListEntityDC GetAllGenderType()
        {
            GenderListEntityDC MemberListEntityDC = new GenderListEntityDC();
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.GetAllGenderType();
        }
        public AdminPropertyEntityDC SaveAdminProperty(AdminPropertyEntityDC Members)
        {
            MembersServiceSoapClient membersrv = new MembersServiceSoapClient();
            return membersrv.SaveAdminProperty(Members);
        }

    }
}
