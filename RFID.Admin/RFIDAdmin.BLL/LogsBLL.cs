using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFIDAdmin.BLL.LogsService;

namespace RFID.Admin.BLL
{
    public class LogsBLL
    {
        public StudentLogEntityDC[] GetAllStudentLogs(string Search, string AccountID, string StartDate, string EndDate, int PageIndex, int PageSize , out int Count)
        {
           
            StudentLogEntityDC[] productResponse = { };
            LogsServiceSoapClient membersrv = new LogsServiceSoapClient();
            productResponse = membersrv.GetAllStudentLogs(Search, AccountID, StartDate, EndDate, PageIndex, PageSize, out Count);
            return productResponse;
        }
    }
}
