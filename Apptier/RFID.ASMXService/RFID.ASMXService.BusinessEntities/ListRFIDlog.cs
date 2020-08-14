using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessEntities
{
    public class ListRFIDlog
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
        public Guid GateTerminalID
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
