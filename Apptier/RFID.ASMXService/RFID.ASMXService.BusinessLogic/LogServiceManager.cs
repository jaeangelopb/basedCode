using RFID.ASMXService.BusinessEntities;
using RFID.ASMXService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessLogic
{
    public class LogServiceManager
    {
        public RFIDLogEntityDC InsertRFIDlog(RFIDLogEntityDC member)
        {
            LogDAL userDAL = new LogDAL();
            RFIDLogEntityDC memberResponse = new RFIDLogEntityDC();
            memberResponse = userDAL.InsertRFIDlog(member);
            return memberResponse;
        }

        public List<SMSRFIDLog> GetAllRFIDLog()
        {
            LogDAL userDAL = new LogDAL();
            List<SMSRFIDLog> memberResponse = new List<SMSRFIDLog>();
            memberResponse = userDAL.GetAllRFIDLog();
            return memberResponse;
        }

        public RFIDLogEntityDC GetLogsByRFID(string RFID)
        {
            RFIDLogEntityDC listOfRFID = new RFIDLogEntityDC();
            LogDAL member = new LogDAL();
            listOfRFID = member.GetLogByRFID(RFID);
            return listOfRFID;
        }
        
        public Guid UpdateRFIDlog(SMSRFIDLog RFIDlog)
        {
            Guid rfID = Guid.Empty;
            LogDAL member = new LogDAL();
            rfID = member.UpdateRFIDlog(RFIDlog);
            return rfID;
        }
        public List<StudentLogEntityDC> GetAllStudentLogs(string Search, string AccountID, string StartDate, string EndDate, int PageIndex, int PageSize, out int Count)

        {
            List<StudentLogEntityDC> productResponse = new List<StudentLogEntityDC>();
            StudentLogEntityDC member = new StudentLogEntityDC();
            LogDAL LogsDAL = new LogDAL();
            productResponse = LogsDAL.GetAllStudentLogs(Search, AccountID, StartDate, EndDate, PageIndex, PageSize, out Count);
            return productResponse;
        }
    }
}
