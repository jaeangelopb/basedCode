using RFID.ASMXService.BusinessEntities;
using RFID.ASMXService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessLogic
{
    public class AccountManager
    {
        public AccountListEntityDC GetAllAccount(string Search, int PageIndex, int PageSize, out int Count)
        {
            AccountListEntityDC productResponse = new AccountListEntityDC();

            AccountDAL memberDAL = new AccountDAL();
            productResponse = memberDAL.GetAllAccount(Search, PageIndex, PageSize, out Count);
            return productResponse;
        }
        public AccountEntityDC SaveAccount(AccountEntityDC member)
        {
            AccountDAL memberDAL = new AccountDAL();

            member = memberDAL.SaveAccount(member);

            return member;
        }

        public AccountListEntityDC GetAccountByID(Guid AccountID)
        {
            AccountListEntityDC productResponse = new AccountListEntityDC();
            AccountEntityDC member = new AccountEntityDC();
            AccountDAL memberDAL = new AccountDAL();
            productResponse = memberDAL.GetAccountByID(AccountID);
            return productResponse;
        }
        public AccountListEntityDC GetAllAccountMemberCount(string Search, int PageIndex, int PageSize, out int Count)
        {
            AccountListEntityDC productResponse = new AccountListEntityDC();
            AccountEntityDC member = new AccountEntityDC();
            AccountDAL memberDAL = new AccountDAL();
            productResponse = memberDAL.GetAllAccountMemberCount(Search, PageIndex, PageSize, out Count);
            return productResponse;
        }
        public AffiliationEntityDC SaveAffilation(AffiliationEntityDC AffiliationEntityDC)
        {
            AffiliationEntityDC productResponse = new AffiliationEntityDC();
           // AccountEntityDC member = new AccountEntityDC();
            AccountDAL memberDAL = new AccountDAL();
            productResponse = memberDAL.SaveAffilation(AffiliationEntityDC);
            return productResponse;
        }
        public DepartmentEntityDC SaveDepertment(DepartmentEntityDC DepartmentEntityDC)
        {
            DepartmentEntityDC productResponse = new DepartmentEntityDC();
           // AccountEntityDC member = new AccountEntityDC();
            AccountDAL memberDAL = new AccountDAL();
            productResponse = memberDAL.SaveDepertment(DepartmentEntityDC);
            return productResponse;
        }
        public AffiliationListEntityDC GetAllAffiliation()
        {
            AffiliationListEntityDC productResponse = new AffiliationListEntityDC();
            // AccountEntityDC member = new AccountEntityDC();
            AccountDAL memberDAL = new AccountDAL();
            productResponse = memberDAL.GetAllAffiliation();
            return productResponse;
        }
        public DepartmentListEntityDC GetAllDepartment()
        {
            DepartmentListEntityDC productResponse = new DepartmentListEntityDC();
            // AccountEntityDC member = new AccountEntityDC();
            AccountDAL memberDAL = new AccountDAL();
            productResponse = memberDAL.GetAllDepartment();
            return productResponse;
        }
    }
}
