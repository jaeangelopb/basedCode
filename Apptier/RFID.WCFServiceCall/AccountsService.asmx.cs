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
    /// Summary description for AccountsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AccountsService : System.Web.Services.WebService
    {

        [WebMethod]
        public AccountEntityDC SaveAccount(AccountEntityDC member)
        {
            AccountManager Manager = new AccountManager();
            member = Manager.SaveAccount(member);
            return member;
        }
        [WebMethod]
        public AccountListEntityDC GetAccountByID(Guid AccountID)
        {
            AccountListEntityDC member = new AccountListEntityDC();
            AccountManager Manager = new AccountManager();
            member = Manager.GetAccountByID(AccountID);
            return member;
        }
        [WebMethod]
        public AccountListEntityDC GetAllAccountMemberCount(string Search, int PageIndex, int PageSize)
        {
            int Count = 0;
            AccountListEntityDC member = new AccountListEntityDC();
            AccountManager Manager = new AccountManager();
            member = Manager.GetAllAccountMemberCount(Search, PageIndex, PageSize, out Count);
            return member;
        }
        [WebMethod]
        public AccountListEntityDC GetAllAccount(string Search, int PageIndex, int PageSize, out int Count)
        {
          
            AccountManager member = new AccountManager();
            AccountListEntityDC ListAccount = new AccountListEntityDC();
            ListAccount = member.GetAllAccount(Search, PageIndex, PageSize, out Count);
            return ListAccount;
        }
        [WebMethod]
        public AffiliationEntityDC SaveAffilation(AffiliationEntityDC AffiliationEntityDC)
        {
            int Count = 0;
            AccountManager member = new AccountManager();
            AffiliationEntityDC ListAccount = new AffiliationEntityDC();
            ListAccount = member.SaveAffilation(AffiliationEntityDC);
            return ListAccount;
        }
        [WebMethod]
        public DepartmentEntityDC SaveDepertment(DepartmentEntityDC DepartmentEntityDC)
        {
            int Count = 0;
            AccountManager member = new AccountManager();
            DepartmentEntityDC ListAccount = new DepartmentEntityDC();
            ListAccount = member.SaveDepertment(DepartmentEntityDC);
            return ListAccount;
        }
        [WebMethod]
        public AffiliationListEntityDC GetAllAffiliation()
        {
            int Count = 0;
            AccountManager member = new AccountManager();
            AffiliationListEntityDC ListAccount = new AffiliationListEntityDC();
            ListAccount = member.GetAllAffiliation();
            return ListAccount;
        }
        [WebMethod]
        public DepartmentListEntityDC GetAllDepartment()
        {
            int Count = 0;
            AccountManager member = new AccountManager();
            DepartmentListEntityDC ListAccount = new DepartmentListEntityDC();
            ListAccount = member.GetAllDepartment();
            return ListAccount;
        }
    }
}
