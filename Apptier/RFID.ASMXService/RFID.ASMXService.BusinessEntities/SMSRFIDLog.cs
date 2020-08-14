using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessEntities
{
    public class SMSRFIDLog
    {
        public Guid RFIDLogID
        {
            get; set;
        }
        public string RFID
        {
            get; set;
        }
        public string DateTimeStamp
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string MiddleName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string MobileNumber
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
        public string LogType
        {
            get; set;
        }
    }
}
