using RFIDAdmin.BLL.AccountsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Admin.BLL
{
    public class AccountBLL
    {
        public AccountListEntityDC GetAllAccount(string search, int pageindex, int pagesize, out int count)
        {
            AccountListEntityDC MemberListEntityDC = new AccountListEntityDC();
            AccountsServiceSoapClient membersrv = new AccountsServiceSoapClient();
            return membersrv.GetAllAccount(search, pageindex, pagesize, out count);
        }
        public AccountEntityDC SaveAccount(AccountEntityDC member)
        {
            AccountsServiceSoapClient membersrv = new AccountsServiceSoapClient();
            return membersrv.SaveAccount(member);
        }

        public AccountListEntityDC GetAccountByID(Guid AccountID)
        {
            AccountListEntityDC MemberListEntityDC = new AccountListEntityDC();
            AccountsServiceSoapClient membersrv = new AccountsServiceSoapClient();
            return membersrv.GetAccountByID(AccountID);
        }
        public AccountListEntityDC GetAllAccountMemberCount(string Search, int PageIndex, int PageSize)
        {
            AccountListEntityDC MemberListEntityDC = new AccountListEntityDC();
            AccountsServiceSoapClient membersrv = new AccountsServiceSoapClient();
            return membersrv.GetAllAccountMemberCount(Search, PageIndex, PageSize);
        }
        public AffiliationListEntityDC GetAllAffiliation()
        {
            //AccountListEntityDC MemberListEntityDC = new AccountListEntityDC();
            AccountsServiceSoapClient membersrv = new AccountsServiceSoapClient();
            return membersrv.GetAllAffiliation();
        }
        public DepartmentListEntityDC GetAllDepartment()
        {
            //AccountListEntityDC MemberListEntityDC = new AccountListEntityDC();
            AccountsServiceSoapClient membersrv = new AccountsServiceSoapClient();
            return membersrv.GetAllDepartment();
        }
        public AffiliationEntityDC SaveAffilation(AffiliationEntityDC AffiliationEntityDC)
        {
            //AccountListEntityDC MemberListEntityDC = new AccountListEntityDC();
            AccountsServiceSoapClient membersrv = new AccountsServiceSoapClient();
            return membersrv.SaveAffilation(AffiliationEntityDC);
        }
        public DepartmentEntityDC SaveDepertment(DepartmentEntityDC DepartmentEntityDC)
        {
            //AccountListEntityDC MemberListEntityDC = new AccountListEntityDC();
            AccountsServiceSoapClient membersrv = new AccountsServiceSoapClient();
            return membersrv.SaveDepertment(DepartmentEntityDC);
        }
    }
}
