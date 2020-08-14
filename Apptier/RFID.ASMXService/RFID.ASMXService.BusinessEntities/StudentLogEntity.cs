using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessEntities
{
   public class StudentLogEntityDC
    {
        public Guid MemberID
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string IDNumber
        {
            get; set;
        }
        public string Affiliation
        {
            get; set;
        }
        public string Department
        {
            get; set;
        }
        public string AccountName
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
        public string LogType
        {
            get; set;
        }
        public string GateTerminalName
        {
            get; set;
        }
    }
    public class StudentLogListEntity
    {
        public List<StudentLogEntityDC> StudentLogList { get; set; }
    }
}
