using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessEntities
{
   public class AccountEntityDC
    {
        public Guid AccountID
        {
            get; set;
        }
        public string Counts
        {
            get; set;
        }
        public string AccountName
        {
            get; set;
        }
        public string Branch
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
        public string EmailAddress
        {
            get; set;
        }
        public string TelephoneNumber
        {
            get; set;
        }
        public string MobileNumber
        {
            get; set;
        }

        public string CreatedBy
        {
            get; set;
        }
        public string CreatedDate
        {
            get; set;
        }
        public string UpdatedBy
        {
            get; set;
        }
        public string UpdatedDate
        {
            get; set;
        }
    }

}
