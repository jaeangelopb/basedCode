using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessEntities
{
    public class AffiliationEntityDC
    {
        public int AffiliationID
        {
            get; set;
        }
        public string AffiliationName
        {
            get; set;
        }
    }
    public class AffiliationListEntityDC
    {
        public List<AffiliationEntityDC> AffiliationList { get; set; }
    }

}