using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessEntities
{
    public class AdminPropertyEntityDC
    {
        public Guid AdminPropertyID
        {
            get; set;
        }

        public Guid AdministratorID
        {
            get; set;
        }
        public Guid AccountID
        {
            get; set;
        }
        public string AccountName
        {
            get; set;
        }
        public bool IsActive
        {
            get; set;
        }
        public string CreatedDate
        {
            get; set;
        }

        
        public string CreatedBy
        {
            get; set;
        }
        public string UpdatedDate
        {
            get; set;
        }
        public string UpdatedBy
        {
            get; set;
        }
    }

}